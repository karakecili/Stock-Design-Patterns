using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockDP.Models
{
    public class Cash
    {
        public string Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Currency { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
