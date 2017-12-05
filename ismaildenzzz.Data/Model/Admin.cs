using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ismaildenzzz.Data.Model
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Ad Soyad :")]
        [MaxLength(255,ErrorMessage ="Gireceğiniz Ad Soyad 255 karakteri geçemez.")]
        [Required]
        public string Adsoyad { get; set; }
        [Display(Name = "Kullanıcı Adı :")]
        [MaxLength(16, ErrorMessage = "Gireceğiniz KullaniciAdi 16 karakteri geçemez."),MinLength(6,ErrorMessage = "6 karakterden az bir KullaniciAdi girilemez.")]
        [Required]
        public string KullaniciAdi { get; set; }
        [Display(Name = "Şifre :")]
        [DataType(DataType.Password)]
        [MaxLength(16, ErrorMessage = "Gireceğiniz Sifre 16 karakteri geçemez."), MinLength(6, ErrorMessage = "6 karakterden az bir Sifre girilemez.")]
        [Required]
        public string Sifre { get; set; }
        [Display(Name = "Kayıt Tarihi :")]
        [Required]
        public DateTime KayitTarihi { get; set; }
        [Display(Name = "Mail :")]
        [Required]
        public string Mail { get; set; }
        [Display(Name ="Aktif :")]
        public bool AktifMi { get; set; }

        public virtual Rol Rol { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
