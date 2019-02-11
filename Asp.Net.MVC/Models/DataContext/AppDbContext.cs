using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Asp.Net.MVC.Models.DataContext
{
    public class AppDbContext : DbContext
    {
        #region Construct

        public AppDbContext()
            :base("DefaultConnection")
        {

        }

        #endregion

        #region DbSet's

        public DbSet<BlogPost> BlogPost { get; set; }

        #endregion
    }
}