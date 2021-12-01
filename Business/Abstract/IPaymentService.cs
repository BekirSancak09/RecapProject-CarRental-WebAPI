﻿using Core.Utilities.Results;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
 public   interface IPaymentService
    {
        IDataResult<List<Payment>> GetAll();
        IDataResult<Payment> GetById(int paymentId);
        IResult Add(Payment payment);
        IResult Update(Payment payment);
        IResult Delete(Payment payment);
    }
}
