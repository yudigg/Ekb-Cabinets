using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EkbDataAccess;
using MvcEKCabinets.Models;

namespace MvcEKCabinets.Controllers
{
    public class CabinetsController : Controller
    {

        public ActionResult Index()
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            HomeViewModel vm = new HomeViewModel { Brands = repo.GetAllBrandInfo() };            
            return View(vm);
        }
        public ActionResult Lines(int brandId)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            HomeViewModel vm = new HomeViewModel { Lines = repo.GetLineInfoByBrand(brandId), Cabinets = repo.GetCabinetInfoByBrand(brandId) };////
            return View(vm);
        }
        //public ActionResult Cabinet(int lineId)
        //{
        //    CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
        //    HomeViewModel vm = new HomeViewModel { Cabinets = repo.GetCabinetInfoByLine(lineId) };
        //    return View(vm);
        //}
        public ActionResult Portfolio()
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            HomeViewModel vm = new HomeViewModel { Portfolios = repo.GetAllPortfolioInfo() };
            return View(vm);
        }
    }
}
