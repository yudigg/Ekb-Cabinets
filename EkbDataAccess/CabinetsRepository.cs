using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkbDataAccess
{
    public class CabinetsRepository
    {
        private string _connectionString;
        public CabinetsRepository(string connection)
        {
            _connectionString = connection;
        }
        public IEnumerable<Line> GetFullRepository()
        {
            using (var dc = new DataClassesDataContext(_connectionString))
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Line>(l => l.Brand);
                loadOptions.LoadWith<Line>(l => l.Cabinets);
                dc.LoadOptions = loadOptions;
                return dc.Lines.ToList();
            }
        }
        public IEnumerable<Cabinet> GetCabinetInfoByLineId(int lineId)
        {
          
            using (var dc = new DataClassesDataContext(_connectionString))
            {
                
                IEnumerable<Cabinet> cabinets = dc.Cabinets.Where(c => c.LineId == lineId).ToList();
                return cabinets;
            }
         
        }
        public IEnumerable<Cabinet> GetAllCabinets()
        {
            using (var dc = new DataClassesDataContext(_connectionString))
            {
                return dc.Cabinets.ToList();
            }
        }
        public void NewCabinet(Cabinet cabinet)
        {
            using (var dc = new DataClassesDataContext(_connectionString))
            {
                dc.Cabinets.InsertOnSubmit(cabinet);
                dc.SubmitChanges();
            }
        }
        public void NewLine(Line line)
        {
            using (var dc = new DataClassesDataContext(_connectionString))
            {
                dc.Lines.InsertOnSubmit(line);
                dc.SubmitChanges();
            }
        }
        public void NewBrand(Brand brand)
        {
            using (var dc = new DataClassesDataContext(_connectionString))
            {
                dc.Brands.InsertOnSubmit(brand);
                dc.SubmitChanges();
            }
        }
        public void UpdateCabinetInfo(Cabinet cabinet)
        {
            using (var dc = new DataClassesDataContext(_connectionString))
            {
                dc.Cabinets.Attach(cabinet);
                dc.Refresh(RefreshMode.KeepCurrentValues, cabinet);
                dc.SubmitChanges();
            }
        }
        public void DeleteCabinet(int cabinetId)
        {
            using (var dc = new DataClassesDataContext(_connectionString))
            {
                dc.ExecuteCommand("DELETE FROM Cabinet WHERE Id = {0}", cabinetId);
            }

        }
        public IEnumerable<Brand> GetAllBrandInfo()
        {
            using (var dc = new DataClassesDataContext(_connectionString))
            {
                return dc.Brands.ToList();
            }
        }
        public IEnumerable<Line> GetLineInfoByBrand(int brandId)
        {
            using (var dc = new DataClassesDataContext(_connectionString))
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Line>(l => l.Cabinets);
                dc.LoadOptions = loadOptions;
                return dc.Lines.Where(l => l.BrandId == brandId).ToList();
            }
        }
        public IEnumerable<Cabinet> GetCabinetInfoByBrand(int brandId)
        {
            using (var dc = new DataClassesDataContext(_connectionString))
            {
                var result = (from c in dc.Cabinets
                              join l in dc.Lines on c.LineId equals l.Id
                              join b in dc.Brands on l.BrandId equals b.Id
                              where b.Id == brandId
                              select c).ToList();
                return result;
            }
        }
        public IEnumerable<Portfolio> GetAllPortfolioInfo()
        {
            using (var dc = new DataClassesDataContext(_connectionString))
            {
                return dc.Portfolios.ToList();
            }
        }
    }
}
