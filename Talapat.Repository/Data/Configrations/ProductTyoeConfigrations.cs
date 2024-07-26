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
    internal class ProductTyoeConfigrations : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(p=>p.Name).IsRequired();
        }
    }
}
