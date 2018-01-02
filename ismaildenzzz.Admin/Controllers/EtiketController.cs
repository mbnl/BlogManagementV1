using ismaildenzzz.Admin.CustomFilter;
using ismaildenzzz.Admin.Models;
using ismaildenzzz.Core.Infrastructure;
using ismaildenzzz.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ismaildenzzz.Admin.Controllers
{
    public class EtiketController : Controller
    {
        #region Etiket
        private readonly IEtiketRepository _etiketRepository;
        public EtiketController(IEtiketRepository etiketRepository)
        {
            _etiketRepository = etiketRepository;
        }
        #endregion
        // GET: Etiket
        [LoginFilter]
        public ActionResult Index()
        {
            return View();
        }
        #region VerileriYükle
        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Client, NoStore = true)]
        public ActionResult LoadData()
        {
            var data = _etiketRepository.GetAll();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region EtiketSil
        public JsonResult Sil(int ID)
        {
            Etiket objEtiket = _etiketRepository.GetByID(ID);
            if (objEtiket == null)
            {
                return Json(new ResultJson { Success = false, Message = "Etiket bulunamadı." });
            }
            _etiketRepository.Delete(ID);
            _etiketRepository.Save();

            return Json(new ResultJson { Success = true, Message = "Etiket silme işleminiz başarılı." });
        }
        #endregion
        #region EtiketDuzenle
        [LoginFilter]
        [HttpGet]
        public ActionResult Duzenle(int ID)
        {
            Etiket objetiket = _etiketRepository.GetByID(ID);
            if (objetiket == null)
            {
                return RedirectToAction("Index", "Etiket");
            }

            return View(objetiket);
        }
        [LoginFilter]
        [HttpPost]
        public JsonResult Duzenle(Etiket etiket)
        {
            try
            {
                etiket.EtiketLink = AboutFileUpload.SeoUrl(etiket.EtiketAdi);
                _etiketRepository.Update(etiket);
                _etiketRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Etiket düzenleme işleminiz başarılı." });
            }
            catch(Exception ex)
            {
                return Json(new ResultJson { Success = true, Message = "Düzenleme işlemi sırasında bir hata oluştu." });
            }
        }
        #endregion
        #region EtiketEkle
        [LoginFilter]
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [LoginFilter]
        [HttpPost]
        public ActionResult Ekle(Etiket etiket)
        {
            try
            {
                etiket.EtiketLink = AboutFileUpload.SeoUrl(etiket.EtiketAdi);
                _etiketRepository.Insert(etiket);
                _etiketRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Etiket ekleme işleminiz başarılı." });
            }
            catch(Exception ex)
            {
                return Json(new ResultJson { Success = true, Message = "Ekleme işlemi sırasında bir hata oluştu." });
            }
            
        }
        #endregion
    }
}