using ismaildenzzz.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ismaildenzzz.Admin.Models
{
    public class BlogViewModel
    {
        public int ID { get; set; }
        public string Baslik { get; set; }
        public string KisaAciklama { get; set; }
        public string Icerik { get; set; }
        public string SeoAnahtarlari { get; set; }
        public string SeoAciklama { get; set; }
        public string YuklenmeTarihi { get; set; }
        public bool? Aktif { get; set; }
        public string Resim { get; set; }
        public string KategoriAdi { get; set; }
        public string AdminAdi { get; set; }
        public ICollection<Etiket> EtiketList { get; set; }
        //public ICollection<Yorum> YorumList { get; set; }
    }
}