using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EkbDataAccess;
using MvcEKCabinets.Models;
using System.IO;
using System.Web.Security;

namespace MvcEKCabinets.Controllers
{
  [LogErrors]
    public class AdminController : Controller
    {
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(string username, string passwd)
        {
            AdminsManager mgr = new AdminsManager(Properties.Settings.Default.Constr);
            mgr.AddAdmin(username, passwd);
            return RedirectToAction("LogIn");
        }
        public ActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AdminIndex");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            AdminsManager mgr = new AdminsManager(Properties.Settings.Default.Constr);
            var adminUser = mgr.GetAdmin(username, password);
            if (adminUser == null)
            {
                return View();
            }
            FormsAuthentication.SetAuthCookie(adminUser.Username, true);
            return RedirectToAction("AdminIndex");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "Cabinets");
        }
        [Authorize]
        public ActionResult AdminIndex()
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);           
            IEnumerable<Brand> brands = repo.GetAllBrandInfo();
            AdminPageModel adm = new AdminPageModel { Brands = brands };
            return View(adm);
        }
        public ActionResult CabinetsIndex(int brandId, string brandName)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            AdminPageModel adm = new AdminPageModel { Lines = repo.GetLineInfoByBrand(brandId), Cabinets = repo.GetCabinetInfoByBrand(brandId) };
            adm.BrandName = brandName;
            return View(adm);
        }

        public ActionResult ViewCabinets(int seriesId)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            IEnumerable<Cabinet> cabinets = repo.GetCabinetInfoByLineId(seriesId);
            List<MyCabinet> cabinetList = new List<MyCabinet>();
            foreach (Cabinet c in cabinets)
            {
                MyCabinet mc = new MyCabinet();
                mc.Id = c.Id;
                mc.LineId = c.LineId;
                mc.Name = c.Name;
                mc.DoorImage = c.DoorImage;
                mc.FullImage = c.FullImage;
                cabinetList.Add(mc);
            }
            return Json(cabinetList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddNewCabinet(string styleName, int lineId, string description, HttpPostedFileBase doorImg, HttpPostedFileBase fullImg)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            Cabinet c = new Cabinet { Name = styleName, LineId = lineId };
            if (doorImg != null)
            {
                if (IsImage(doorImg))
                {
                    c.DoorImage = SavedImgName(doorImg);
                }
            }
            if (fullImg != null)
            {
                if (IsImage(fullImg))
                {
                    c.FullImage = SavedImgName(fullImg);
                }
            }
            repo.NewCabinet(c);
            return RedirectToAction("AdminIndex");
        }
        [HttpPost]
        public ActionResult AddNewSeries(string name, int brandId,string description)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            Line l = new Line { Name = name, BrandId = brandId, Description = description };
            repo.NewLine(l);

            return RedirectToAction("AdminIndex");
        }
        [HttpPost]
        public ActionResult AddNewBrand(string name, HttpPostedFileBase logoImg)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            if (logoImg != null)
            {
                if (IsImage(logoImg))
                {
                    var fileName = SavedImgName(logoImg);
                    Brand b = new Brand { Name = name, LogoFile = fileName };
                    repo.NewBrand(b);
                }
            }           
            return RedirectToAction("AdminIndex");
        }
        [HttpPost]
        public ActionResult AddPortfolio(int lineId, HttpPostedFileBase portfolioImg)//prob put in db brand also
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            if (portfolioImg != null)
            {
                if (IsImage(portfolioImg))
                {
                    var fileName = SavedImgName(portfolioImg);///probably better to assign guid to db...
                    Portfolio p = new Portfolio { LineId = lineId, Image = fileName };
                    repo.NewPortfolio(p);
                }
            }
            return RedirectToAction("AdminIndex");
        }
        public ActionResult EditCabinets(int seriesId)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            IEnumerable<Cabinet> c = repo.GetCabinetInfoByLineId(seriesId);
            return View(c);
        }

        [HttpPost]
        public ActionResult EditCabinets(Cabinet c, HttpPostedFileBase doorImg, HttpPostedFileBase fullImg)
        {
                CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
                if (doorImg != null)
                {
                    if (IsImage(doorImg))
                    {
                        c.DoorImage = SavedImgName(doorImg);
                    }
                }
                if (fullImg != null)
                {
                    if (IsImage(fullImg))
                    {
                        c.FullImage = SavedImgName(fullImg);
                    }
                }               
                repo.UpdateCabinetInfo(c);            
            return RedirectToAction("AdminIndex");
        }
    [HttpPost]
        public void DeleteCabinet(int cabinetId)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            repo.DeleteCabinet(cabinetId);
        }
        //delete brand and line
        private bool IsImage(HttpPostedFileBase file)
        {
            if (file.ContentType.Contains("image"))
            {
                return true;
            }
            string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

            foreach (var item in formats)
            {
                if (file.FileName.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }
        private string SavedImgName(HttpPostedFileBase img)
        {
            var fileName = Path.GetFileName(img.FileName);
            img.SaveAs(Server.MapPath("~/Uploads/" + fileName));
            return fileName;
        }
    }
}
