using ismaildenzzz.Admin.CustomFilter;
using ismaildenzzz.Core.Infrastructure;
using ismaildenzzz.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ismaildenzzz.Admin.Controllers
{
    public class AdminController : Controller
    {
        #region Admin
        private readonly IBlogRepository _blogRepository;
        private readonly IEtiketRepository _etiketRepository;
        private readonly IKategoriRepository _kategoriRepository;
        private readonly IYorumRepository _yorumRepository;
        private readonly BlogContext _context = new BlogContext();

        public AdminController(IBlogRepository blogRepository, IEtiketRepository etiketRepository, IKategoriRepository kategoriRepository, IYorumRepository yorumRepository)
        {
            _blogRepository = blogRepository;
            _etiketRepository = etiketRepository;
            _kategoriRepository = kategoriRepository;
            _yorumRepository = yorumRepository;
        }
        #endregion

        // GET: Admin
        [LoginFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}