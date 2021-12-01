using Core.Utilities.Results;
using Entities.Concrate;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {

        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<List<CarDetailDto>> GetCarDetailsByCar(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndByBrand(int colorId, int brandId);
        IDataResult<Car> GetById(int carId);

        IResult Add(Car car);

        IResult Delete(Car car);

        IResult Update(Car car);


    }
}
