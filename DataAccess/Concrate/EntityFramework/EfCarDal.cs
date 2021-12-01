using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrate.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Func<CarDetailDto, bool> filter = null)
        {
            using (RentACarContext context= new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 MinFindeksPoint=c.MinFindeksPoint,
                                 ImagePath = (from m in context.CarImages where m.CarId == c.CarId select m.ImagePath).ToList(),
                                 IsRentable =!context.Rentals.Any(r=>r.CarId==c.CarId) || !context.Rentals.Any(r => r.CarId == c.CarId && (r.ReturnDate == null || (r.ReturnDate.HasValue && r.ReturnDate > DateTime.Now)))

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
