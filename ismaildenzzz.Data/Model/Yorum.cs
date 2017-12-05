using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ismaildenzzz.Data.Model
{
    [Table("Yorum")]
    public class Yorum
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100, ErrorMessage = "Ad Soyad 100 karakterden fazla olamaz.")]
        [Display(Name = "Ad Soyad :")]
        [Required]
        public string Adsoyad { get; set; }
        [MaxLength(100, ErrorMessage = "Mail 100 karakterden fazla olamaz.")]
        [Display(Name = "Mail :")]
        [Required]
        public string Mail { get; set; }
        [MaxLength(100, ErrorMessage = "Site 100 karakterden fazla olamaz.")]
        [Display(Name = "Site :")]
        public string Site { get; set; }
        [Display(Name = "Yorum :")]
        [Required]
        public string YorumMesaj { get; set; }
        [DefaultValue(0)]
        public int Onay { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
