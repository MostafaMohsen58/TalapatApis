using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talapat.Core.Entities;
using Talapat.Core.Repositories;

namespace Talapat.Repository
{
    public class BasketRepository : IBasketRepository
    {

        private readonly IDatabase _database;
        public BasketRepository( IConnectionMultiplexer redis) // ask clr to inject obj from class implement IconnectionMultiplexer
        {
                _database=redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string BasketId)
        {
           return await _database.KeyDeleteAsync(BasketId);
        }

        public async Task<CustomerBasket?> GetBasketAsync(string BasketId)
        {
           var Basket = await _database.StringGetAsync(BasketId);
            //if (Basket.IsNull) return null;
            //else
            //    return JsonSerializer.Deserialize<CustomerBasket?>(Basket); 
            return Basket.IsNull ? null : JsonSerializer.Deserialize<CustomerBasket?>(Basket);
        }

        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket Basket)
        {// customer basket=> redis value
            
            var jsonbasket= JsonSerializer.Serialize(Basket);
          var createdORUpdated=  await _database.StringSetAsync(Basket.ID,jsonbasket,TimeSpan.FromDays(1));
            if (!createdORUpdated) return null;
            return await GetBasketAsync(Basket.ID);

        }
    }
}
