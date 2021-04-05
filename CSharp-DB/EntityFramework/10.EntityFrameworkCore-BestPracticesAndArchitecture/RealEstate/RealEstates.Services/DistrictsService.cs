using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    public class DistrictsService : IDistrictsService
    {
        private RealEstateDbContext dbContext;

        public DistrictsService(RealEstateDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<DistrictViewModel> GetTopDistrictsByAveragePrice(int count = 10)
        {
            return this.dbContext.Districts
                .OrderByDescending(x => x.RealEstateProperties.Average(z => z.Price))
                .Select(MapDistrictViewModel())
                .Take(count)
                .ToList();
        }
        
        public IEnumerable<DistrictViewModel> GetTopDistrictsByNumberOfProperties(int count = 10)
        {
            return this.dbContext.Districts
                .OrderByDescending(x => x.RealEstateProperties.Count())
                .Select(MapDistrictViewModel())
                .Take(count)
                .ToList();
        }

        private static Expression<Func<District, DistrictViewModel>> MapDistrictViewModel()
        {
            return x => new DistrictViewModel()
            {
                Name = x.Name,
                AveragePrice = x.RealEstateProperties.Average(x => x.Price),
                MaxPrice = x.RealEstateProperties.Max(x => x.Price),
                MinPrice = x.RealEstateProperties.Min(x => x.Price),
                PropertiesCount = x.RealEstateProperties.Count()
            };
        }
    }
}
