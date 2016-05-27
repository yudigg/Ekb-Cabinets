using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EkbDataAccess;

namespace MvcEKCabinets.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult AdminIndex()
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            IEnumerable<Cabinet> all = repo.GetFullRepository();
            return View(all);
        }
        [HttpPost]
        public ActionResult AddNewCabinet(string name, int lineId, int brandId, string descripton, HttpPostedFileBase doorImg, HttpPostedFileBase fullImg)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            Guid gDoor = new Guid();
            Guid gFull = new Guid();
            string fileNameDoorImg = gDoor + ".jpg";
            string fileNameFullImg = gFull + ".jpg";
            doorImg.SaveAs(Server.MapPath("~/Uploads/" + fileNameDoorImg));
            fullImg.SaveAs(Server.MapPath("~/Uploads/" + fileNameFullImg));
            Cabinet c = new Cabinet { Name = name, LineId = lineId, BrandId = brandId, Description = descripton };
            c.DoorImage = fileNameDoorImg;
            c.FullImage = fileNameFullImg;
            repo.NewCabinet(c);

            return RedirectToAction("AdminIndex");
        }
        [HttpPost]
        public ActionResult AddNewLine(string name, int brandId)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            Line l = new Line { Name = name, BrandId = brandId };
            repo.NewLine(l);

            return RedirectToAction("AdminIndex");
        }
        [HttpPost]
        public ActionResult AddNewBrand(string name, HttpPostedFileBase logoFile)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            Guid g = new Guid();
            string fileName = g + ".jpg";
            logoFile.SaveAs(Server.MapPath("~/Uploads/" + fileName));
            Brand b = new Brand { Name = name, LogoFile = fileName };
            repo.NewBrand(b);
            return RedirectToAction("AdminIndex");
        }
        public ActionResult EditCabinet(Cabinet c, string guidDoorImg, string FullImg)
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
