using System.Collections.Generic;

namespace StockDP.Models
{
    public static class Context
    {
        static List<Currency> Currency = null;

        static List<Cash> Cash = null;

        static Context()
        {
            Cash = new List<Cash>();
        }

        public static List<Currency> GetCurrency()
        {
            return Currency;
        }

        public static List<Cash> GetCash()
        {
            return Cash;
        }
    }
}
