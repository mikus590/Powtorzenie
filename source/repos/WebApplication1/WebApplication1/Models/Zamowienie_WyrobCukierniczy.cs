using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Zamowienie_WyrobCukierniczy
    {
        public int IdWyrobuCukierniczego
        {
            get; set;
        }
        public int IdZamowienia {
            get;set;
        } 
        public int Ilosc
        {
            get;set;
        }
        [MaxLength(300)]
        public string Uwagi
        {
            get;set;
        }
        [ForeignKey("IdZamowienia")]
        public virtual Zamówienie Zamowienie { get; set; }
        [ForeignKey("IdWyrobuCukierniczego")]
        public virtual WyrobCukierniczy Wyrob { get; set; }
    }
}
