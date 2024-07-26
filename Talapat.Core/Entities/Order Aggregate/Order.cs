using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talapat.Core.Entities.Order_Aggregate
{
    public class Order:BaseEntity
    {
        public Order()
        {
                
        }
        public Order(string buyerName, Address shippingAddress, DeliveyMethod deliveryMethod, ICollection<OrderItem> items, decimal subTotal)
        {
            BuyerName = buyerName;
            this.shippingAddress = shippingAddress;
            DeliveryMethod = deliveryMethod;
            Items = items;
            SubTotal = subTotal;
        }

        public string BuyerName { get; set; }
        public DateTimeOffset OrderDate { get; set; }=DateTimeOffset.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public Address shippingAddress { get; set; }// not Nav property because Address wil not be represented in database
     //  public int DeliveyMethodId { get; set; } // FK
        public DeliveyMethod DeliveryMethod { get; set; }// Navigtional property because DM is table in Database

         public ICollection<OrderItem> Items { get; set;} = new HashSet<OrderItem>();

        public decimal SubTotal {  get; set; }



        //   [NotMapped]
        // public decimal Total { get => SubTotal * DeliveyMethod.Cost; } //Driven Attribute will not be represented in database
    // Same Thing but represent as fun
        public decimal GetTotal() => SubTotal + DeliveryMethod.Cost;
        public string PaymentIntendId { get; set; } = string.Empty;

    }
}
