using ismaildenzzz.Admin.CustomFilter;
using ismaildenzzz.Admin.Models;
using ismaildenzzz.Core.Infrastructure;
using ismaildenzzz.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ismaildenzzz.Admin.Controllers
{
    public class KategoriAdminController : Controller
    {
        #region Kategori
        private readonly IKategoriRepository _kategoriRepository;
        public KategoriAdminController(IKategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }
        #endregion
        // GET: Kategori
        [LoginFilter]
        public ActionResult Index()
        {
            return View();
        }

        #region VerileriYükle
        [LoginFilter]
        public ActionResult LoadData()
        {
            var data = _kategoriRepository.GetAll();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region KategoriSil
        [LoginFilter]
        public JsonResult Sil(int ID)
        {
            Kategori objEtiket = _kategoriRepository.GetByID(ID);
            if (objEtiket == null)
            {
                return Json(new ResultJson { Success = false, Message = "Kategori bulunamadı." });
            }
            _kategoriRepository.Delete(ID);
            _kategoriRepository.Save();

            return Json(new ResultJson { Success = true, Message = "Kategori silme işleminiz başarılı." });
        }
        #endregion
        #region KategoriDuzenle
        [LoginFilter]
        [HttpGet]
        public ActionResult Duzenle(int ID)
        {
            Kategori objetiket = _kategoriRepository.GetByID(ID);
            if (objetiket == null)
            {
                return RedirectToAction("Index", "Kategori");
            }

            return View(objetiket);
        }
        [LoginFilter]
        [HttpPost]
        public JsonResult Duzenle(Kategori kategori)
        {
            kategori.KategoriLink = AboutFileUpload.SeoUrl(kategori.KategoriAdi);
            try
            {
                _kategoriRepository.Update(kategori);
                _kategoriRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Kategori düzenleme işleminiz başarılı." });
            }
            catch(Exception ex)
            {
                return Json(new ResultJson { Success = true, Message = "Düzenleme işlemi sırasında bir hata oluştu." });
            }
        }
        #endregion
        #region KategoriEkle
        [LoginFilter]
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [LoginFilter]
        [HttpPost]
        public ActionResult Ekle(Kategori kategori)
        {
            try
            {
                kategori.KategoriLink = AboutFileUpload.SeoUrl(kategori.KategoriAdi);
                _kategoriRepository.Insert(kategori);
                _kategoriRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Kategori ekleme işleminiz başarılı." });
            }
            catch(Exception ex)
            {
                return Json(new ResultJson { Success = true, Message = "Kategori işlemi sırasında bir hata oluştu." });
            }
            
        }
        #endregion
    }
}