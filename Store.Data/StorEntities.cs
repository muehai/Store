using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using Store.Model.Model;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Data.Configuration;

namespace Store.Data
{
    public class StorEntities : DbContext
    {
        public StorEntities()
        {

        }
        public StorEntities(DbContextOptions<StorEntities> StoreEntitiesDb) : base (StoreEntitiesDb) { }
         
        public DbSet<Gadget> Gadgets { get; set; } 
        public DbSet<Category> Categories { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new GadgetConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }


    }
}
