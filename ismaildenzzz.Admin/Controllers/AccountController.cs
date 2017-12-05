using ismaildenzzz.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ismaildenzzz.Data.Model;
using System.Web.Security;
using ismaildenzzz.Admin.CustomFilter;

namespace ismaildenzzz.Admin.Controllers
{
    public class AccountController : Controller
    {
        #region Admin
        private readonly IAdminRepository _adminRepository;
        public AccountController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        #endregion
        [LoginFilter]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ismaildenzzz.Data.Model.Admin admin)
        {
            var AdminVarmi = _adminRepository.GetMany(x => x.KullaniciAdi == admin.KullaniciAdi && x.Sifre == admin.Sifre).SingleOrDefault();
            if(AdminVarmi != null)
            {
                if(AdminVarmi.Rol.RolAdi == "Admin")
                {
                    Session["KullaniciAdi"] = AdminVarmi.KullaniciAdi;
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Mesaj = "Yetkisiz admin";
                return View();
            }
            ViewBag.Mesaj = "Admin bulunamadı";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}