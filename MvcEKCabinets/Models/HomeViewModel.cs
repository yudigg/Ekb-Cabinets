using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EkbDataAccess;

namespace MvcEKCabinets.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Line> Lines { get; set; }
        public IEnumerable<Cabinet> Cabinets { get; set; }
        public IEnumerable<Portfolio> Portfolios{ get; set; }
        public string BrandName { get; set; }
        public Line Line { get; set; }
        public IEnumerable<GetCabinetsAndLogoByLineIDResult> CabinetsWithLogo { get; set; }
        public string LogoFile { get; set; }
    }
}