using ismaildenzzz.Admin.CustomFilter;
using ismaildenzzz.Admin.Models;
using ismaildenzzz.Core.Infrastructure;
using ismaildenzzz.Data.DataContext;
using ismaildenzzz.Data.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ismaildenzzz.Admin.Controllers
{
    public class BlogController : Controller
    {
        #region Blog
        private readonly IBlogRepository _blogRepository;
        private readonly IKategoriRepository _kategoriRepository;
        private readonly IEtiketRepository _etiketRepository;
        private readonly IYorumRepository _yorumRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly BlogContext _context = new BlogContext();

        public BlogController(IBlogRepository blogRepository, IKategoriRepository kategoriRepository, IEtiketRepository etiketRepository, IAdminRepository adminRepository,IYorumRepository yorumRepository)
        {
            _blogRepository = blogRepository;
            _kategoriRepository = kategoriRepository;
            _etiketRepository = etiketRepository;
            _adminRepository = adminRepository;
            _yorumRepository = yorumRepository;
        }
        #endregion

        [LoginFilter]
        public ActionResult Index()
        {
            return View();
        }
        #region VerileriYükle
        [ValidateInput(false)]
        public ActionResult LoadData() // Tamamen döndürülen obje ile alakalı bir sorun var.
        {
            //BlogViewModel objBlogVM;
            //var data = _blogRepository.GetAll();
            List<BlogViewModel> data = _context.Blog.Select(x => new BlogViewModel
            {
                ID = x.ID,
                Baslik = x.Baslik,
                KisaAciklama = x.KisaAciklama,
                Icerik = x.Icerik,
                SeoAnahtarlari = x.SeoAnahtarlari,
                SeoAciklama = x.SeoAciklama,
                YuklenmeTarihi = x.YuklenmeTarihi.ToString(),
                Aktif = x.Aktif,
                Resim = string.IsNullOrEmpty(x.Resim) ? "/Content/images/no-image.png" : x.Resim,
                KategoriAdi = x.Kategori.KategoriAdi,
                AdminAdi = x.Admin.Adsoyad,
                EtiketList = x.Etikets
                //YorumList = x.Yorums
            }).ToList();

            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region BlogSil
        [LoginFilter]
        public JsonResult Sil(int ID)
        {
            Blog objBlog  = _blogRepository.GetByID(ID);
            List<Yorum> yorumList = _context.Yorum.Where(x => x.Blog.ID == ID).ToList();
            //List<Etiket> etiketList = _context.Etiket.Where(x => x.Blog.ID == ID).ToList();
            if (objBlog == null)
            {
                return Json(new ResultJson { Success = false, Message = "Blog bulunamadı." });
            }
            if(yorumList != null)
            {
                foreach(Yorum data in yorumList)
                {
                    _yorumRepository.Delete(data.ID);
                }
                _yorumRepository.Save();
            }
            
            _blogRepository.Delete(ID);
            _blogRepository.Save();

            return Json(new ResultJson { Success = true, Message = "Blog silme işleminiz başarılı." });
        }
        #endregion

        #region BlogEkle
        [LoginFilter]
        [HttpGet]
        public ActionResult Ekle()
        {
            SetKategoriListele();
            SetEtiketListele();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Ekle(Blog blog, int[] Etiketler, HttpPostedFileBase file)
        {
            try
            {
                string encodeFileName;
                string path;
                Random random = new Random();
                if (ModelState.IsValid)
                {
                    blog.YuklenmeTarihi = DateTime.Now;
                    blog.Aktif = true;
                    blog.AdminID = 1;
                    blog.SeoLink = AboutFileUpload.SeoUrl(blog.Baslik);
                    blog.Hit = 0;
                    blog.Icerik = blog.Icerik.Trim().Replace(" ", string.Empty); ;
                    if (file != null)
                    {
                        string extension = Path.GetExtension(file.FileName);
                        string softName = System.IO.Path.GetFileName(file.FileName);
                        if (extension == ".png" || extension == ".jpg" || extension == ".gif")
                        {
                            softName = softName.Substring(0, softName.Length - 4);
                        }
                        else if (extension == ".jpeg")
                        {
                            softName = softName.Substring(0, softName.Length - 5);
                        }
                        encodeFileName = softName + "-" + AboutFileUpload.RandomString(8) + extension;
                        path = System.IO.Path.Combine(Server.MapPath("~/Content/uploads"), encodeFileName);
                        file.SaveAs(path);
                        blog.Resim = "/Content/uploads/" + encodeFileName;
                    }
                    
                    if (Etiketler != null)
                    {
                        blog.Etikets = new List<Etiket>();
                        for (int i = 0; i < Etiketler.Length; i++)
                        {
                            Etiket objEtiket = _etiketRepository.GetByID(Etiketler[i]);
                            _context.Etiket.Attach(objEtiket);
                            blog.Etikets.Add(objEtiket);

                        }
                    }
                    _context.Blog.Add(blog);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Blog");
                }
            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = true, Message = "Blog işlemi sırasında bir hata oluştu." });
            }
            return Json(new ResultJson { Success = true, Message = "Blog ekleme işleminiz başarısız." });
        }
        #endregion

        #region SetKategoriListesi
        public void SetKategoriListele(object kategori = null)
        {
            var KategoriList = _kategoriRepository.GetAll();
            ViewBag.Kategori = KategoriList;
        }
        #endregion
        #region SetEtiketListesi
        public void SetEtiketListele(object etiket = null)
        {
            var EtiketList = _etiketRepository.GetAll();
            ViewBag.Etiket = new MultiSelectList(EtiketList, "ID", "EtiketAdi");
        }
        #endregion
    }
}