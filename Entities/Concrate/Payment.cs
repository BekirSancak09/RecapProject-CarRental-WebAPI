using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrate
{
   public class Payment:IEntity
    {
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
