using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talapat.Core.Entities.Order_Aggregate
{
    public class DeliveyMethod:BaseEntity
    {
        public DeliveyMethod()
        {
                
        }
        public DeliveyMethod(string shortName, string discribtion, string deliveryTime, decimal cost)
        {
            ShortName = shortName;
            Discribtion = discribtion;
            DeliveryTime = deliveryTime;
            Cost = cost;
        }
        public string ShortName { get; set; }
        public string Discribtion { get; set; }
        public string DeliveryTime { get; set; }
        public decimal Cost { get; set; }

    }
}
