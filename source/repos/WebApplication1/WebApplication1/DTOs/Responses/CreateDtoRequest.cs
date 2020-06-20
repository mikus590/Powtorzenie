using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.DTOs.Responses
{
    public class CreateDtoRequest
    {

        public class WyrobDtoRequest
        {
            public int Ilosc { get; set; }
            public string Wyrob { get; set; }
            public string Uwagi { get; set; }
        }
        public DateTime DataPrzyjecia { get; set; }
        public string Uwagi { get; set; }
        public ICollection<WyrobDtoRequest> Wyroby { get; set; }
    }
}
