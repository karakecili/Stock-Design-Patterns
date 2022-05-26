using Microsoft.AspNetCore.Mvc;
using StockDP.Models;
using StockDP.Observer;
using StockDP.Strategy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockDP.Controllers
{
    public class StockController : Controller
    {
        //Strateji tipine göre gelecek
        private readonly ICalculate _calculate;
        //Observer
        private readonly CashObserverSubject _cashObserverSubject;

        static readonly List<Currency> Currency = new List<Currency>()
        {
            new Currency { Id = 1, Name = "Türk Lirası", Abbreviation = "TL", Rate = 1.00M },
            new Currency { Id = 2, Name = "Amerikan Doları", Abbreviation = "USD", Rate = 15.00M },
            new Currency { Id = 3, Name = "Euro", Abbreviation = "EUR", Rate = 16.00M },
        };

        public StockController(ICalculate calculate, CashObserverSubject cashObserverSubject)
        {
            _calculate = new CalculateEUR();
            _cashObserverSubject = cashObserverSubject;
        }

        public IActionResult Index()
        {
            return View(_calculate.Calculate());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(decimal Price)
        {
            if (ModelState.IsValid)
            {
                var _newCash = _calculate.Save(Price);
                if (_newCash.Currency != 1 && _newCash.Price > 100)
                {
                    //Observer işlemi burada
                    _cashObserverSubject.NotifyObserver(_newCash);
                }
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
