using ismaildenzzz.Admin.CustomFilter;
using ismaildenzzz.Admin.Models;
using ismaildenzzz.Core.Infrastructure;
using ismaildenzzz.Core.Repository;
using ismaildenzzz.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ismaildenzzz.Admin.Controllers
{
    public class IletisimController : Controller
    {
        #region Iletisim
        public ILetisimRepository _iletisimRepository;
        public IletisimController(ILetisimRepository iletisimRepository)
        {
            _iletisimRepository = iletisimRepository;
        }
        #endregion
        // GET: Iletisim
        [LoginFilter]
        public ActionResult Index()
        {
            return View();
        }
        #region VerileriYükle
        public ActionResult LoadData() // Tamamen döndürülen obje ile alakalı bir sorun var.
        {
            var data = _iletisimRepository.GetAll();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region IletisimEkle
        [HttpPost]
        public ActionResult Ekle(Iletisim yorum)
        {
            try
            {
                _iletisimRepository.Insert(yorum);
                _iletisimRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Blog ekleme işleminiz başarılı." });
            }
            catch (Exception ex)
            {
                return Json(new ResultJson { Success = true, Message = "Blog işlemi sırasında bir hata oluştu." });
            }
        }
        #endregion

        #region IletisimSil
        public ActionResult Sil(int ID)
        {
            try
            {
                Iletisim objIletisim = _iletisimRepository.GetByID(ID);
                if(objIletisim == null)
                {
                    return Json(new ResultJson { Success = true, Message = "Iletişim Mesajı bulunamadı." });
                }
                _iletisimRepository.Delete(ID);
                _iletisimRepository.Save();
                return Json(new ResultJson { Success = true, Message = "Iletişim Mesajı Başarıyla Silindi." });
            }catch(Exception ex)
            {
                return Json(new ResultJson { Success = true, Message = "Iletişim Mesajı Silinirken Hata Meydana Geldi." });
            }
        }
        #endregion

        #region IletisimDetay
        [LoginFilter]
        public ActionResult Detay(int id) // Tamamen döndürülen obje ile alakalı bir sorun var.
        {
            Iletisim data = _iletisimRepository.GetByID(id);
            if (data == null)
            {
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }
            return PartialView("_Detay", data);
        }
        #endregion

    }
}