using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EkbDataAccess;
using MvcEKCabinets.Models;

namespace MvcEKCabinets.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult AdminIndex()
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            IEnumerable<Line> all = repo.GetFullRepository();
            IEnumerable<Cabinet> cabinets = repo.GetAllCabinets();
            IEnumerable<Brand> brands = repo.GetAllBrandInfo();
            AdminPageModel adm = new AdminPageModel { Lines = all, Cabinets = cabinets, Brands =brands };
            return View(adm);
        }
        public ActionResult CabinetsIndex(int brandId,string brandName)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            AdminPageModel adm = new AdminPageModel {  Lines = repo.GetLineInfoByBrand(brandId), Cabinets = repo.GetCabinetInfoByBrand(brandId)};
            adm.BrandName = brandName;
            return View(adm);
        }
      
        public ActionResult ViewCabinets(int seriesId)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
           IEnumerable<Cabinet> cabinets = repo.GetCabinetInfoByLineId(seriesId);
          // int numbers = 123;
          // string x = cabinets.First().Name;
           return Json(cabinets, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddNewCabinet(string styleName, int lineId,string description, HttpPostedFileBase doorImg, HttpPostedFileBase fullImg)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            Guid gDoor = Guid.NewGuid();
            Guid gFull = Guid.NewGuid();
            string fileNameDoorImg = gDoor + ".jpg";
            string fileNameFullImg = gFull + ".jpg";
            doorImg.SaveAs(Server.MapPath("~/Uploads/" + fileNameDoorImg));
            fullImg.SaveAs(Server.MapPath("~/Uploads/" + fileNameFullImg));
            Cabinet c = new Cabinet { Name = styleName, LineId = lineId };
            c.DoorImage = fileNameDoorImg;
            c.FullImage = fileNameFullImg;
            repo.NewCabinet(c);
            return RedirectToAction("AdminIndex");
        }
        [HttpPost]
        public ActionResult AddNewSeries(string name, int brandId)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            Line l = new Line { Name = name, BrandId = brandId };
            repo.NewLine(l);

            return RedirectToAction("AdminIndex");
        }
        [HttpPost]
        public ActionResult AddNewBrand(string name, HttpPostedFileBase logoImg)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            Guid g = Guid.NewGuid();
            string fileName = g + ".jpg";
            logoImg.SaveAs(Server.MapPath("~/Uploads/" + fileName));
            Brand b = new Brand { Name = name, LogoFile = fileName };
            repo.NewBrand(b);
            return RedirectToAction("AdminIndex");
        }
        public ActionResult EditCabinets(int seriesId)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
          IEnumerable<Cabinet> c =  repo.GetCabinetInfoByLineId(seriesId);
            return View(c);
        }
        [HttpPost]
        public ActionResult EditCabinets(Cabinet c, string guidDoorImg, string FullImg)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            c.DoorImage = guidDoorImg;
            c.FullImage = FullImg;
            repo.UpdateCabinetInfo(c);
            return RedirectToAction("AdminIndex");
        }
        public ActionResult DeleteCabinet(int cabinetId)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            repo.DeleteCabinet(cabinetId);


            return RedirectToAction("AdminIndex");
        }
        //delete brand and line
    }
}
