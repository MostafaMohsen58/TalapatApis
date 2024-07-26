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
    public class OrderConfigration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // builder represent order
            builder.Property(O=>O.Status)
                .HasConversion(OStatus=> OStatus.ToString(),OStatus=> (OrderStatus) Enum.Parse(typeof(OrderStatus),OStatus));

            builder.Property(O => O.SubTotal)
                .HasColumnType("decimal(18,2)");
            builder.OwnsOne(O => O.shippingAddress, SA => SA.WithOwner());
            builder.HasOne(o => o.DeliveryMethod)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
