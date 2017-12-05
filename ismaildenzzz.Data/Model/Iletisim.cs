using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ismaildenzzz.Data.Model
{
    [Table("Iletisim")]
    public class Iletisim
    {
        [Key]
        public int ID { get; set; }
        public string IP { get; set; }
        [MaxLength(100,ErrorMessage ="Ad Soyad 100 karakterden fazla olamaz.")]
        [Display(Name ="Ad Soyad :")]
        [Required]
        public string Adsoyad { get; set; }
        [MaxLength(100, ErrorMessage = "Mail 100 karakterden fazla olamaz.")]
        [Display(Name = "Mail :")]
        [Required]
        public string Mail { get; set; }
        [MaxLength(100, ErrorMessage = "Konu 100 karakterden fazla olamaz.")]
        [Display(Name = "Konu :")]
        public string Konu { get; set; }
        [Display(Name = "Mesaj :")]
        [Required]
        public string Mesaj { get; set; }
    }
}
