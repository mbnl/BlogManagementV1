using ismaildenzzz.Core.Infrastructure;
using ismaildenzzz.Data.DataContext;
using ismaildenzzz.Data.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ismaildenzzz.Admin.Controllers
{
    [RoutePrefix("kategori")]
    public class KategoriUIController : Controller
    {
        #region KategoriUI
        private readonly IBlogRepository _blogRepository;
        private readonly IEtiketRepository _etiketRepository;
        private readonly IKategoriRepository _kategoriRepository;

        public KategoriUIController(IBlogRepository blogRepository, IEtiketRepository etiketRepository, IKategoriRepository kategoriRepository, IYorumRepository yorumRepository)
        {
            _blogRepository = blogRepository;
            _etiketRepository = etiketRepository;
            _kategoriRepository = kategoriRepository;
        }
        #endregion
        

        [HttpGet]
        [Route("{KategoriLink}")]
        public ActionResult Detay(string KategoriLink)
        {
            #region ORTAK
            ViewBag.Etikets = _etiketRepository.GetAll();
            ViewBag.Kategoris = _kategoriRepository.GetAll();
            List<int> countByCategoryID = new List<int>();
            List<int> countByEtiketID = new List<int>();
            foreach (var item in _kategoriRepository.GetAll())
            {
                countByCategoryID.Add(_kategoriRepository.CountByLink(item.KategoriLink));
            }
            foreach (var item in _etiketRepository.GetAll())
            {
                countByEtiketID.Add(_etiketRepository.CountByObject(item));
            }
            ViewBag.KategoriPostSayilari = countByCategoryID;
            ViewBag.EtiketPostSayilari = countByEtiketID;
            #endregion
            Kategori kategoriObj = _kategoriRepository.Get(x => x.KategoriLink == KategoriLink);
            ViewBag.Kategori = kategoriObj;
            IEnumerable<Blog> blogModel = _blogRepository.GetMany(x => x.Kategori.KategoriAdi == KategoriLink).ToList();
            return View(blogModel);
        }
    }
}