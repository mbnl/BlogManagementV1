using ismaildenzzz.Admin.CustomFilter;
using ismaildenzzz.Admin.Models;
using ismaildenzzz.Core.Infrastructure;
using ismaildenzzz.Data.DataContext;
using ismaildenzzz.Data.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ismaildenzzz.Admin.Controllers
{
    public class HomeController : Controller
    {
        #region Blog
        private readonly IBlogRepository _blogRepository;
        private readonly IEtiketRepository _etiketRepository;
        private readonly IKategoriRepository _kategoriRepository;

        public HomeController(IBlogRepository blogRepository, IEtiketRepository etiketRepository, IKategoriRepository kategoriRepository)
        {
            _blogRepository = blogRepository;
            _etiketRepository = etiketRepository;
            _kategoriRepository = kategoriRepository;
        }
        #endregion

        [HttpGet]
        public ActionResult Index(string page)
        {
            int pageSize = 12;
            int pageIndex = 1;
            int n;
            bool isNumeric = int.TryParse(page, out n);
            if (isNumeric)
            {
                if (!string.IsNullOrEmpty(page))
                    pageIndex = Convert.ToInt32(page);
            }
           

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
            IPagedList<Blog> blogList = _blogRepository.GetAll().ToPagedList(pageIndex,pageSize);
            ViewBag.BirSayfadakiPostlar = blogList;
            return View(blogList);
        }
        
        public ActionResult Robots()
        {
            Response.ContentType = "text/plain";
            return View();
        }
    }
}