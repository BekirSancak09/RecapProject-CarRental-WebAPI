using Core.DataAccess;
using Entities.Concrate;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICarDal: IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails(Func<CarDetailDto, bool> filter = null);
    }
}
