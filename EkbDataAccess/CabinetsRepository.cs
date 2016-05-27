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
        public IEnumerable<Cabinet> GetFullRepository()
        {
            using (var dc = new DataClassesDataContext(_connectionString))
            {
                var loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Cabinet>(c => c.Brand);
                loadOptions.LoadWith<Cabinet>(c => c.Line);
                dc.LoadOptions = loadOptions;
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
            using(var dc = new DataClassesDataContext(_connectionString))
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
                return dc.Lines.Where(l => l.BrandId == brandId).ToList();
            }
        }
        public IEnumerable<Cabinet> GetCabinetInfoByBrand(int brandId)
        {
            using (var dc = new DataClassesDataContext(_connectionString))
            {
                return dc.Cabinets.Where(c => c.BrandId == brandId).ToList();
            }
        }
        public IEnumerable<Portfolio>GetAllPortfolioInfo()
        {
            using (var dc = new DataClassesDataContext(_connectionString))
            {
                return dc.Portfolios.ToList();
            }
        }
    }
}
