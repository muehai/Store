using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Model.Model;


          

namespace Store.Data.Configuration
{
    public class CategoryConfiguration: IEntityTypeConfiguration<Category> 
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Add to table

            //ToTable("Categories");
            builder.HasKey(c => c.CategoryId);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.CategoryId).IsRequired();

        }
         
    }
}
