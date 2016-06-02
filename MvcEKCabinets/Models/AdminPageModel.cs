using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EkbDataAccess;

namespace MvcEKCabinets.Models
{
    public class AdminPageModel
    {
       public IEnumerable<Line> Lines { get; set; }
       public IEnumerable<Cabinet> Cabinets { get; set; }
       public IEnumerable<Brand> Brands { get; set; }
       public string BrandName { get; set; }
    }
}