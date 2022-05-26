using StockDP.Models;
using System;
using System.Collections.Generic;

namespace StockDP.Strategy
{
    class CalculateEUR : ICalculate
    {
        private readonly Currency _currency;

        public CalculateEUR()
        {
            _currency = Context.GetCurrency().Find(x => x.Abbreviation == "EUR");
        }

        public List<Cash> Calculate()
        {
            return Context.GetCash();
        }

        public void Delete(string Id)
        {
            Context.GetCash().RemoveAll(x => x.Id == Id);
        }

        public Cash Save(decimal Price)
        {
            var _newCash = new Cash
            {
                Id = Guid.NewGuid().ToString(),
                Price = _currency.Rate * Price,
                Currency = _currency.Id,
                CreatedTime = DateTime.Now
            };
            Context.GetCash().Add(_newCash);
            return _newCash;
        }

        public Cash Update(string Id, decimal Price)
        {
            var item = Context.GetCash().Find(x => x.Id == Id);
            item.Price = Price;
            item.Currency = _currency.Id;
            return item;
        }
    }
}
