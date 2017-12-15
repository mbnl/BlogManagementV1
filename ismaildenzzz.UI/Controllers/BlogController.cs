using ismaildenzzz.Core.Infrastructure;
using ismaildenzzz.Data.DataContext;
using ismaildenzzz.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ismaildenzzz.UI.Controllers
{
    public class BlogController : Controller
    {
        #region Blog
        private readonly IBlogRepository _blogRepository;
        private readonly IEtiketRepository _etiketRepository;
        private readonly IKategoriRepository _kategoriRepository;
        private readonly BlogContext _context = new BlogContext();

        public BlogController(IBlogRepository blogRepository,IEtiketRepository etiketRepository,IKategoriRepository kategoriRepository)
        {
            _blogRepository = blogRepository;
            _etiketRepository = etiketRepository;
            _kategoriRepository = kategoriRepository;
        }
        #endregion

        // GET: Blog
        public ActionResult Index()
        {
            ViewBag.Etikets = _etiketRepository.GetAll();
            ViewBag.Kategoris = _kategoriRepository.GetAll();
            IEnumerable<Blog> blogList = _blogRepository.GetAll();
            return View(blogList);
        }
    }
}