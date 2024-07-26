using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Entities.Order_Aggregate;

namespace Talapat.Core.Services
{
    public interface IorderService
    {
        Task<Order> CreateOrderAsync(string buyerName, string basketId, int DeliveryMethod, Address ShippingAddress);
        Task<IReadOnlyList<Order>> CreateOrderforspecificuserasync(string buyeremail);
        Task<Order> CreateOrderByidforspecificuserasync(string buyerEmail, int orderId);
    }
}
