using ismaildenzzz.Admin.Models;
using ismaildenzzz.Core.Infrastructure;
using ismaildenzzz.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ismaildenzzz.Admin.Controllers
{
    public class SearchController : Controller
    {
        #region Search
        private readonly IBlogRepository _blogRepository;
        private readonly IEtiketRepository _etiketRepository;
        private readonly IKategoriRepository _kategoriRepository;
        private readonly IYorumRepository _yorumRepository;
        private readonly BlogContext _context = new BlogContext();

        public SearchController(IBlogRepository blogRepository, IEtiketRepository etiketRepository, IKategoriRepository kategoriRepository, IYorumRepository yorumRepository)
        {
            _blogRepository = blogRepository;
            _etiketRepository = etiketRepository;
            _kategoriRepository = kategoriRepository;
            _yorumRepository = yorumRepository;
        }
        #endregion

        // GET: Search
        [Route("search")]
        public async Task<ViewResult> Index(string q)
        {
            var tasks = new Task[3];
            int i = 0;
            SearchModel viewModel = new SearchModel();
            viewModel.SearchKey = q;
            List<Task> TaskList = GetSeachResult(q, viewModel);
            foreach (Task tsk in TaskList)
            {
                tasks[i] = tsk;
                i++;
            }
            await Task.WhenAll(tasks);

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

            return View(viewModel);
        }

        //public async Task<ViewResult> Search(string q)
        //{
            
        //}

        private List<Task> GetSeachResult(string search, SearchModel model)
        {
            //NorthContext dbContext = new NorthContext();
            List<Task> Tasks = new List<Task>();
            var taskBlogBaslik = Task.Factory.StartNew(() =>
            {
                using (BlogContext dbContext = new BlogContext())
                {
                    model.BlogList = dbContext.Blog.Where(cus => cus.Baslik.Contains(search)).ToList();
                }
            });
            Tasks.Add(taskBlogBaslik);
            var taskEtiketAdi = Task.Factory.StartNew(() =>
            {
                using (BlogContext dbContext = new BlogContext())
                {
                    model.EtiketList = dbContext.Etiket.Where(sup => sup.EtiketAdi.Contains(search)).ToList();
                }
            });
            Tasks.Add(taskEtiketAdi);
            var taskKategoriAdi = Task.Factory.StartNew(() =>
            {
                using (BlogContext dbContext = new BlogContext())
                {
                    model.KategoriList = dbContext.Kategori.Where(emp => emp.KategoriAdi.Contains(search)).ToList();
                }
            });
            Tasks.Add(taskKategoriAdi);
            return Tasks;
        }
    }
}