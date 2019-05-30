using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class CustomerContext:DbContext
    {
        public CustomerContext():base("CustomerContext")
        {

        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
}