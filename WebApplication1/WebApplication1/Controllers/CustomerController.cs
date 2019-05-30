using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using WebApplication1.Models;
using WebApplication1.Providers;
using WebApplication1.Results;
using System.Linq;

namespace WebApplication1.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        public CustomerController()
        {
        }

        // GET api/Account/UserInfo
        [Route("GetCustomer")]
        public dynamic GetCustomer(decimal id, string email)
        {
            if (id == null)
            {
                if (string.IsNullOrEmpty(email))
                {
                    return new HttpError("No inquiry criteria");
                }

                return new HttpError("Invalid Customer ID");
            }
            else if (string.IsNullOrEmpty(email))
            {
                return new HttpError("Invalid Email");
            }

            using (devEntities db = new devEntities())
            {
                Customer cust = db.Customers.Where(x => x.CustomerID == id && x.ContactEmail == email).FirstOrDefault();
                if (cust == null)
                    return new HttpError("Not Found");

                CustomerViewModel view = new CustomerViewModel();
                view.CustomerID = cust.CustomerID;
                view.CustomerName = cust.CustomerName;
                view.ContactEmail = cust.ContactEmail;
                view.MobileNo = cust.MobileNo;

                var transaction = db.Transactions.Where(x => x.Customer == cust.CustomerID).ToList();

                foreach (var t in transaction)
                {
                    if (view.RecentTransaction.Count >= 5) break;
                    var v = new TransactionViewModel();
                    v.TransactionID = t.TransactionID;
                    v.TransactionDateTime = t.TransactionDateTime;
                    v.Amount = t.Amount;
                    v.CurrencyCode = t.CurrencyCode;
                    v.Status = t.Status;
                    view.RecentTransaction.Add(v);
                }

                return view;
            }

            return new HttpError("Bad Request");
        }

    }
}
