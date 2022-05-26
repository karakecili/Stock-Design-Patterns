using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StockDP.Models;

namespace StockDP.Strategy
{
    public interface ICalculate
    {
        List<Cash> Calculate();

        Cash Save(decimal Price);

        Cash Update(string Id, decimal Price);

        void Delete(string Id);
    }
}
