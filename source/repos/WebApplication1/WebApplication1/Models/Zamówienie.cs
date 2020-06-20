using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Zamówienie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [MaxLength(300)]
        public string Uwagi
        {
            get; set;
        }
        public int IdKlient
        {
            get; set;
        }
        [ForeignKey("IdKlient")]
        public virtual Klient Klient{ get; set; }
        public int IdPracownik
        {
            get; set;
        }
        [ForeignKey("IdPracownik")]
        public virtual Pracownik Pracownik { get; set; }

        public virtual ICollection<Zamowienie_WyrobCukierniczy> ZamowienieWyrob { get; set; }

    }
}
