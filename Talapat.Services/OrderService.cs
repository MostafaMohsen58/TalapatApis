using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Entities;
using Talapat.Core.Entities.Order_Aggregate;
using Talapat.Core.Repositories;
using Talapat.Core.Services;

namespace Talapat.Services
{
    public class OrderService : IorderService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IgenericRepository<Product> _productRepo;
        private readonly IgenericRepository<DeliveyMethod> _deliverymehodrepo;
        private readonly IgenericRepository<Order> _orderrepo;

        public OrderService(IBasketRepository basketRepository,
            IgenericRepository<Product> ProductRepo,
            IgenericRepository<DeliveyMethod> Deliverymehodrepo,
            IgenericRepository<Order> orderrepo)
        {
            _basketRepository = basketRepository;
            _productRepo = ProductRepo;
            _deliverymehodrepo = Deliverymehodrepo;
            _orderrepo = orderrepo;
        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, string basketId, int DeliveryMethod, Address ShippingAddress)
        {


            // 1. get basket from basketRepo
            var basket = await _basketRepository.GetBasketAsync(basketId);


            //2. get selected item at basket from product repo 


            var orderitems = new List<OrderItem>();
            if (basket?.items.Count > 0)
            {
                foreach (var item in basket.items)
                {
                    var product = await _productRepo.GetByIdAsync(item.Id);
                    var productitemorder = new ProductItemOrdered(product.Id, product.Name, product.PictureUrl);
                    var orderitem = new OrderItem(productitemorder,product.Price,item.Quantity);

                    orderitems.Add(orderitem);

                }

            }

            // calculate subtotal   price of product* quantity

            var subtotal = orderitems.Sum(item => item.Price * item.Quantity);



            // Get delivery method from delivery method repo 

            var deliverymethod = await _deliverymehodrepo.GetByIdAsync(DeliveryMethod);


            // create order
            var order = new Order(buyerEmail, ShippingAddress, deliverymethod, orderitems, subtotal);
            // add order localy 
            await _orderrepo.Add(order);
            // save order to database
            return order;








        }

        public Task<Order> CreateOrderByidforspecificuserasync(string buyerEmail, int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> CreateOrderforspecificuserasync(string buyeremail)
        {
            throw new NotImplementedException();
        }
    }
}
