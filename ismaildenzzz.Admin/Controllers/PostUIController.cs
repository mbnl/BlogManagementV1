using ismaildenzzz.Core.Infrastructure;
using ismaildenzzz.Data.DataContext;
using ismaildenzzz.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ismaildenzzz.Admin.Controllers
{
    [RoutePrefix("post")]
    public class PostUIController : Controller
    {
        #region Post
        private readonly IBlogRepository _blogRepository;
        private readonly IEtiketRepository _etiketRepository;
        private readonly IKategoriRepository _kategoriRepository;
        private readonly IYorumRepository _yorumRepository;

        public PostUIController(IBlogRepository blogRepository, IEtiketRepository etiketRepository, IKategoriRepository kategoriRepository, IYorumRepository yorumRepository)
        {
            _blogRepository = blogRepository;
            _etiketRepository = etiketRepository;
            _kategoriRepository = kategoriRepository;
            _yorumRepository = yorumRepository;
        }
        #endregion

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("{SeoLink}")]
        public ActionResult Detay(string SeoLink)
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
            ViewBag.Yorums = _yorumRepository.GetMany(x => x.Blog.SeoLink == SeoLink);
            Blog blogModel = _blogRepository.Get(x => x.SeoLink == SeoLink);
            return View(blogModel);
        }
        [HttpPost]
        public JsonResult LoadData(string SeoLink)
        {
            Blog blogModel = _blogRepository.Get(x => x.SeoLink == SeoLink);
            var Icerik = blogModel.Icerik;
            return Json(Icerik);
        }
    }
}