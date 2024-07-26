using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Entities;

namespace Talapat.Repository.Data.Configrations
{
    internal class ProductConfigrations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.productBrand)
                 .WithMany()
                 .HasForeignKey(P=>P.ProductBrandId);


            builder.HasOne(p=>p.ProductType) 
                .WithMany()
                .HasForeignKey(P=>P.ProductTypeId);


            builder.Property(p=>p.Name)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p=>p.PictureUrl).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        }
    }
}
