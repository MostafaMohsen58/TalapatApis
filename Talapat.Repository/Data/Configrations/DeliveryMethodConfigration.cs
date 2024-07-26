using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Entities.Order_Aggregate;

namespace Talapat.Repository.Data.Configrations
{
    public class DeliveryMethodConfigration : IEntityTypeConfiguration<DeliveyMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveyMethod> builder)
        {
            builder.Property(DM => DM.Cost).HasColumnType("decimal(18,2)");
        }
    }
}
