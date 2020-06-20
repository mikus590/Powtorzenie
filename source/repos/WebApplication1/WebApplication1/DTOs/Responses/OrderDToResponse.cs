using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DTOs.Responses
{
    public class OrderDToResponse
    {
        public int IdZamówienia
        {
            get; set;
        }

        public DateTime DataPrzyjecia
        {
            get; set;
        }

        public DateTime? DataRealizacji
        {
            get; set;
        }

        public string Uwagi
        {
            get; set;
        }

        public ICollection<WyrobCukierniczy> Wyroby {
            get;set;
        }


    }
}
