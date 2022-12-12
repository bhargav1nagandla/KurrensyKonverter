using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Models
{
    public class Currency
    {
        public float amount { get; set; }

        [Column("base")]
        public string _base { get; set; }

        public string _date { get; set; }

        public string rates {get;set;}

     


    }
}
