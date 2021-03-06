﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ismaildenzzz.Data.Model
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Başlık :")]
        [Required]
        public string Baslik { get; set; }
        [Display(Name ="Kısa Açıklama :")]
        [Required]
        public string KisaAciklama { get; set; }
        [MinLength(50,ErrorMessage ="Açıklama 50 karakterden az olamaz.")]
        [Display(Name ="İçerik :")]
        [UIHint("tinymce_jquery_full")]
        [Required]
        public string Icerik { get; set; }
        [MaxLength(200,ErrorMessage ="Seo Anahtarları 200 karakterden fazla olamaz.")]
        [Display(Name ="Seo Keys :")]
        public string SeoAnahtarlari { get; set; }
        [MaxLength(250, ErrorMessage = "Seo Aciklama 250 karakterden fazla olamaz.")]
        [Display(Name = "Seo Aciklama :")]
        public string SeoAciklama { get; set; }
        [Display(Name = "Yuklenme Tarihi :")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime YuklenmeTarihi { get; set; }
        [Display(Name ="Aktif :")]
        public bool Aktif { get; set; }
        [Display(Name = "Resim Yolu :")]
        public string Resim { get; set; }
        [Display(Name = "Seo Uyumlu Link :")]
        public string SeoLink { get; set; }
        [Display(Name = "Görüntülenme Sayısı :")]
        [DefaultValue(0)]
        public int? Hit { get; set; }
        public int KategoriID { get; set; }
        public int? AdminID { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual Admin Admin { get; set; }
        public ICollection<Etiket> Etikets { get; set; }
        public ICollection<Yorum> Yorums { get; set; }
        

    }
}
