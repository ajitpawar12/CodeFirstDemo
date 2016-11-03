using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CodeFirstDemo.Models;

namespace CodeFirstDemo.Context
{
    public class ProductContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}