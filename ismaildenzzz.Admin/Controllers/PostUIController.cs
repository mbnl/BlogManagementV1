using ismaildenzzz.Admin.CustomFilter;
using ismaildenzzz.Core.Infrastructure;
using ismaildenzzz.Data.Model;
using System.Collections.Generic;
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
        [ResponseCompressFilter]
        public ActionResult Detay(string SeoLink)
        {
            #region ORTAK
            ViewBag.Kategoris = _kategoriRepository.GetAll();
            List<int> countByCategoryID = new List<int>();
            foreach (var item in _kategoriRepository.GetAll())
            {
                countByCategoryID.Add(_blogRepository.CountByKategori(item.ID));
            }
            ViewBag.KategoriPostSayilari = countByCategoryID;
            #endregion
            ViewBag.Yorums = _yorumRepository.GetMany(x => x.Blog.SeoLink == SeoLink);
            Blog blogModel = _blogRepository.Get(x => x.SeoLink == SeoLink);
            blogModel.Hit++;
            _blogRepository.Update(blogModel);
            _blogRepository.Save();
            return View(blogModel);
        }
    }
}