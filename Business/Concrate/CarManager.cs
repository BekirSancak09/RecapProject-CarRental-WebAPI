using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class CarManager : ICarService
    {

         ICarDal _carDal;
         ICustomerService _customerService;
        public CarManager(ICarDal carDal,ICustomerService customerService)
        {
            _carDal = carDal;
            _customerService = customerService;
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation(roles: "car.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountColorCorrect(car.CarId),CheckIfCustomerLimitExceded());
            if (result != null)
            {
                return result;
            }


            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }


       [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

       
       [CacheAspect]
       public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.Listed);
        }


        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return  new SuccessDataResult<Car>(_carDal.Get(r=> r.CarId==carId),Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails(),Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == brandId), Messages.Listed);

        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByCar(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.CarId == carId), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorAndByBrand(int colorId, int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == colorId && c.BrandId==brandId), Messages.Listed);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
             _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfCarCountColorCorrect(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId).Count;
            if (result > 10)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckIfCustomerLimitExceded()
        {
            var result = _customerService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult();
            }
            return new SuccessResult();

        }


    }
}
