using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrate
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        ICustomerService _customerService;
        public RentalManager(IRentalDal rentalDal,ICarService carService,ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }


        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        [SecuredOperation(roles: "rental.add")]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(IsCarAvailable(rental.CarId), CheckIfFindeks(rental.CarId, rental.CustomerId));
            if (result != null)
            {
                return new ErrorResult();
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);
        }


        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }


        [CacheAspect]
        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>( _rentalDal.Get(r => r.RentalId == rentalId),Messages.Listed);
        }



        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }

        public IResult IsCarAvailable(int carId)
        {
            var result=_rentalDal.GetAll(c=> c.CarId==carId && ( c.ReturnDate==null || c.ReturnDate>DateTime.Now)).Any();
            if (result)
            {
                return new ErrorResult(Messages.NotAvailable);
            }
            return new SuccessResult();
        }

        public IResult CheckIfFindeks(int carId, int customerId)
        {
            var customer = _customerService.GetById(customerId).Data;
            var car = _carService.GetById(carId).Data;
            if (customer.FindeksPoint < car.MinFindeksPoint)
            {
                return new ErrorResult(Messages.FindeksPointNotEnough);
            }
            return new SuccessResult();
        }
    }
}
