using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talapat.Core.Entities
{
    public class CustomerBasket
    {

        public string ID { get; set; }
        public List<BasketItem> items { get; set; }
        public CustomerBasket( string id)
        {
            ID = id;
        }
    }
}
