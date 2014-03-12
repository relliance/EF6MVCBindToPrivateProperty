using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyDemo.Models
{
    public class FortKnoxContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FortKnoxContext() : base("name=DefaultConnection")
        {   
        }

        public System.Data.Entity.DbSet<MyDemo.Models.FortKnox> FortKnoxes { get; set; }

        /// <summary>
        /// Overriding the default OnModelCreating to allow us to map FortKnox's ValueForDB as TopSecret
        /// which will allow us to read TopSecret in the app but always store it in the DB as encrypted!
        /// </summary>
        /// <param name="modelBuilder">The model builder EF passes in that we can manipulate to do our bidding</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // model definition is additive so other declaration will be applied on top rather than replacing this one
            modelBuilder.Configurations.Add(new FortKnox.FortKnoxConfig());

            // no harm leaving this in as EF binding is additive
            base.OnModelCreating(modelBuilder);
        }
    }
}
