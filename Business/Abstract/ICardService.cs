using Core.Utilities.Results;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICardService
    {
        IDataResult<List<Card>> GetAll();

        IDataResult<Card> GetById(int cardId);

        IDataResult<List<Card>> GetCardsByCustomerId(int customerId);
        IResult Add(Card card);
        IResult Update(Card card);
        IResult Delete(Card card);
    }
}
