using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ismaildenzzz.Admin.Models
{
    public class YorumViewModel
    {
        public int ID { get; set; }
        public string AdSoyad { get; set; }
        public string Mail { get; set; }
        public string Site { get; set; }
        public string YorumMesaj { get; set; }
        public int Onay { get; set; }
        public string BlogAdi { get; set; }
    }
}