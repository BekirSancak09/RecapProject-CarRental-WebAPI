using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class CardManager:ICardService
    {
         ICardDal _cardDal;
        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public IResult Add(Card card)
        {
            _cardDal.Add(card);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Card card)
        {
            _cardDal.Delete(card);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Card>> GetAll()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Card> GetById(int cardId)
        {
            return new SuccessDataResult<Card>(_cardDal.Get(c => c.CardId == cardId),Messages.Listed);
        }

        public IDataResult<List<Card>> GetCardsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(c=> c.CustomerId==customerId), Messages.Listed);
        }

        public IResult Update(Card card)
        {
            _cardDal.Update(card);
            return new SuccessResult(Messages.Updated);
        }
    }
}
