using ismaildenzzz.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ismaildenzzz.Admin.Models
{
    public class SearchModel
    {
        public List<Blog> BlogList { get; set; }
        public List<Etiket> EtiketList { get; set; }
        public List<Kategori> KategoriList { get; set; }
        public string SearchKey { get; set; }
    }
}