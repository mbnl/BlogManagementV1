using ismaildenzzz.Admin.CustomFilter;
using ismaildenzzz.Admin.Models;
using ismaildenzzz.Core.Infrastructure;
using ismaildenzzz.Data.DataContext;
using ismaildenzzz.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ismaildenzzz.Admin.Controllers
{
    public class YorumController : Controller
    {
        #region Yorum
        private readonly IYorumRepository _yorumRepository;
        private readonly BlogContext _context = new BlogContext();
        public YorumController(IYorumRepository yorumRepository)
        {
            _yorumRepository = yorumRepository;
        }
        #endregion

        // GET: Yorum
        [LoginFilter]
        public ActionResult Index()
        {
            return View();
        }
        #region VerileriYükle
        public ActionResult LoadData() // Tamamen döndürülen obje ile alakalı bir sorun var.
        {
            List<YorumViewModel> data = _context.Yorum.Select(x => new YorumViewModel
            {
                ID = x.ID,
                AdSoyad = x.Adsoyad,
                Mail = x.Mail,
                Site = x.Site,
                YorumMesaj = x.YorumMesaj,
                BlogAdi = x.Blog.Baslik,
                Onay = x.Onay
            }).ToList();
            
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region YorumEkle
        [HttpPost]
        public ActionResult Ekle(Yorum yorum)
        {
            try
            {
                _yorumRepository.Insert(yorum);
                _yorumRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Blog ekleme işleminiz başarılı." });
            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = true, Message = "Blog işlemi sırasında bir hata oluştu." });
            }
            return Json(new ResultJson { Success = true, Message = "Blog ekleme işleminiz başarısız." });
        }
        #endregion
        #region YorumSil
        [LoginFilter]
        public ActionResult Sil(int ID)
        {
            Yorum objYorum = _yorumRepository.GetByID(ID);
            if(objYorum == null)
            {
                return Json(new ResultJson { Success = false, Message = "Yorum bulunamadı." });
            }
            _yorumRepository.Delete(ID);
            _yorumRepository.Save();
            return Json(new ResultJson { Success = true, Message = "Yorum silme işleminiz başarılı." });
        }
        #endregion
        #region YorumOnayla
        [LoginFilter]
        public ActionResult Onayla(int ID)
        {
            Yorum objYorum = _yorumRepository.GetByID(ID);
            if (objYorum == null)
            {
                return Json(new ResultJson { Success = false, Message = "Yorum bulunamadı." });
            }
            objYorum.Onay = 1;
            _yorumRepository.Update(objYorum);
            _yorumRepository.Save();
            return Json(new ResultJson { Success = true, Message = "Yorum onaylama işleminiz başarılı." });
        }
        #endregion
        #region YorumDetay
        [LoginFilter]
        public ActionResult Detay(int id) // Tamamen döndürülen obje ile alakalı bir sorun var.
        {
            Yorum data = _yorumRepository.GetByID(id);
            if(data == null)
            {
                return Json(new {}, JsonRequestBehavior.AllowGet);
            }
            YorumViewModel viewData = new YorumViewModel{
                ID = data.ID,
                AdSoyad = data.Adsoyad,
                Mail = data.Mail,
                Site = data.Site,
                YorumMesaj = data.YorumMesaj,
                BlogAdi = data.Blog.Baslik,
                Onay = data.Onay
            };
            return PartialView("_Detay", viewData);
        }
        #endregion
    }
}