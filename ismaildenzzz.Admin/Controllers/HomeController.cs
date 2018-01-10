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
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

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
            foreach (var item in _kategoriRepository.GetAll())
            {
                countByCategoryID.Add(_blogRepository.CountByKategori(item.ID));
            }
            ViewBag.KategoriPostSayilari = countByCategoryID;
            #endregion
            IPagedList<Blog> blogList = _blogRepository.GetAll().ToPagedList(pageIndex, pageSize);
            ViewBag.BirSayfadakiPostlar = blogList;
            return View(blogList);
        }

        [Route("sitemap.xml")]
        public ActionResult SitemapXml()
        {
            var sitemapNodes = GetSitemapNodes(this.Url);
            string xml = GetSitemapDocument(sitemapNodes);
            return this.Content(xml, MediaTypeNames.Text.Xml, Encoding.UTF8);
        }

        public IReadOnlyCollection<Models.SiteMapNode> GetSitemapNodes(UrlHelper urlHelper)
        {
            List<Models.SiteMapNode> nodes = new List<Models.SiteMapNode>();

            nodes.Add(
                new Models.SiteMapNode()
                {
                    Url = "http://ismaildenzzz.com/iletisim",
                    Priority = 1
                });
            nodes.Add(
               new Models.SiteMapNode()
               {
                   Url = "http://ismaildenzzz.com/hakkimda",
                   Priority = 0.9
               });
            nodes.Add(
               new Models.SiteMapNode()
               {
                   Url = "http://ismaildenzzz.com/",
                   Priority = 0.9
               });

            foreach (string postLink in _blogRepository.GetAll().Select(x => x.SeoLink))
            {
                nodes.Add(
                   new Models.SiteMapNode()
                   {
                       Url = "http://ismaildenzzz.com/post/"+postLink,
                       Frequency = SitemapFrequency.Daily,
                       Priority = 0.8
                   });
            }

            foreach (string etiketLink in _etiketRepository.GetAll().Select(x => x.EtiketLink))
            {
                nodes.Add(
                   new Models.SiteMapNode()
                   {
                       Url = "http://ismaildenzzz.com/etiket/" + etiketLink,
                       Frequency = SitemapFrequency.Daily,
                       Priority = 0.8
                   });
            }

            foreach (string kategoriLink in _kategoriRepository.GetAll().Select(x => x.KategoriLink))
            {
                nodes.Add(
                   new Models.SiteMapNode()
                   {
                       Url = "http://ismaildenzzz.com/kategori/" + kategoriLink,
                       Frequency = SitemapFrequency.Daily,
                       Priority = 0.8
                   });
            }

            return nodes;
        }

        public string GetSitemapDocument(IEnumerable<Models.SiteMapNode> sitemapNodes)
        {
            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (Models.SiteMapNode sitemapNode in sitemapNodes)
            {
                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", Uri.EscapeUriString(sitemapNode.Url)),
                    sitemapNode.LastModified == null ? null : new XElement(
                        xmlns + "lastmod",
                        sitemapNode.LastModified.Value.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    sitemapNode.Frequency == null ? null : new XElement(
                        xmlns + "changefreq",
                        sitemapNode.Frequency.Value.ToString().ToLowerInvariant()),
                    sitemapNode.Priority == null ? null : new XElement(
                        xmlns + "priority",
                        sitemapNode.Priority.Value.ToString("F1", CultureInfo.InvariantCulture)));
                root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();
        }

    }
}