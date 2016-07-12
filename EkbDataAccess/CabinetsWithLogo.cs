using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkbDataAccess
{
    public class CabinetsWithLogo : Cabinet
    {
        public string Logo { get; set; }
        public string LineName { get; set; }
        public string Description { get;set;}
    }
}