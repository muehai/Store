using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Model.Model;


namespace Store.Data.Configuration
{
    public class GadgetConfiguration : IEntityTypeConfiguration<Gadget>
    {
        public void Configure(EntityTypeBuilder<Gadget> builder)
        {
            //ToTable("Gadgets");

            builder.HasKey(c => c.GadgetId);
            builder.Property(c => c.Name).HasMaxLength(50);
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.CategoryID).IsRequired();

        }
    }
}
