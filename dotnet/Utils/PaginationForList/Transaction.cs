using System;
using System.ComponentModel.DataAnnotations;

namespace sampleApi.Utils.PaginationForList
{
    public class Transaction
    {
        [Key]
        public string id { get; set; }
        public DateTime time { get; set; }
        public Decimal amount { get; set; }
    }
}