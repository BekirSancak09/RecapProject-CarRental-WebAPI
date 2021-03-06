using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrate
{
    public class Car:IEntity
    {
     
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }

        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }

        public string Description { get; set; }
        public int MinFindeksPoint { get; set; }
    }
}
