using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Klient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdKlient
        {
            get; set;
        }
        [MaxLength(50)]
        public string Imie
        {
            get; set;
        }
        [MaxLength(60)]
        [Required]
        public string Nazwisko
        {
            get; set;
        }

        public ICollection<Zamówienie> Zamowienia { get; set; }
    }
}
