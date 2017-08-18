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
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Blog>().Property(b => b._Tags).HasColumnName("Tags");
            //modelBuilder.Entity<Blog>().Property(b => b._Owner).HasColumnName("Owner");
        }
    }
}