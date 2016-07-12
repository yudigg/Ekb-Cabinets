using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EkbDataAccess;
using MvcEKCabinets.Models;

namespace MvcEKCabinets.Controllers
{
    [LogErrors]
    public class CabinetsController : Controller
    {

        public ActionResult Index()
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            HomeViewModel vm = new HomeViewModel { Brands = repo.GetBrandsWithLines() };
            return View(vm);
        }
        public ActionResult Lines(int? brandId, int? lineId,string logoFile,string name)
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            HomeViewModel vm;
            if (brandId != null)
            {
                vm = new HomeViewModel { Lines = repo.GetLineInfoByBrand(brandId.Value), Cabinets = repo.GetCabinetInfoByBrand(brandId.Value)};//, BrandName = repo.GetBrandNameById(brandId.Value) };////
                vm.LogoFile = logoFile;
                vm.BrandName = name;
            }
            else
            {
                vm = new HomeViewModel { CabinetsWithLogo = repo.GetCabinetAndLogoByLineId(lineId)};
            }
            return View(vm);
        }

        public ActionResult Portfolio()
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            HomeViewModel vm = new HomeViewModel { Portfolios = repo.GetAllPortfolioInfo() };
            return View(vm);
        }
      public ActionResult StyledIndex()
        {
            CabinetsRepository repo = new CabinetsRepository(Properties.Settings.Default.Constr);
            HomeViewModel vm = new HomeViewModel { Brands = repo.GetAllBrandInfo() };
            return View(vm);
        }
    }
}
