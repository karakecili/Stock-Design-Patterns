using StockDP.Models;
using System.Collections.Generic;

namespace StockDP.Observer
{
    public class CashObserverSubject
    {
        private readonly List<ICashObserver> _cashObservers;

        public void RegisterObserver(ICashObserver cashObserver)
        {
            _cashObservers.Add(cashObserver);
        }


        public void RemoveObserver(ICashObserver cashObserver)
        {
            _cashObservers.Remove(cashObserver);
        }


        public void NotifyObserver(Cash cash)
        {
            _cashObservers.ForEach(x =>
            {
                x.CashControl(cash);
            });
        }
    }
}
