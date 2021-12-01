using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class PaymentManager:IPaymentService
    {

         IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        [SecuredOperation(roles: "redtal.add")]
        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Payment>> GetAll()
        {
           return new SuccessDataResult<List<Payment>>( _paymentDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Payment> GetById(int paymentId)
        {
            return new SuccessDataResult<Payment>( _paymentDal.Get(p => p.PaymentId == paymentId),Messages.Listed);
        }

        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult(Messages.Updated);
        }
    }
}
