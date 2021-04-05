using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    //After we created IPropertiesService we create PropertyService which inherits the interface with our main functions IPropertiesService
    public class PropertyService : IPropertiesService
    {
        //We create private property of dbContext 
        private RealEstateDbContext dbContext;

        //Then we use dependency inversion principle to call give the constructor value from outside
        public PropertyService(RealEstateDbContext context)
        {
            this.dbContext = context;
        }

        public void Create(string district, int size, int? year, int price, string propertyType, string buildingType, int? floor,
            int? maxFloors)
        {

            if (district == null)
            {
                throw new ArgumentNullException(nameof(district));
            }

            var property = new RealEstateProperty()
            {
                Size = size,
                BuildingYear = year,
                Price = price,
                Floor = floor,
                TotalNumberOfFloors = maxFloors
            };

            if (property.BuildingYear < 1800)
            {
                property.BuildingYear = null;
            }

            if (property.Floor <= 0)
            {
                property.Floor = null;
            }

            if (property.TotalNumberOfFloors <= 0)
            {
                property.TotalNumberOfFloors = null;
            }

            //Check District
            var districtEntity =
                this.dbContext.Districts.FirstOrDefault(x => x.Name.Trim() == district.Trim());

            if (districtEntity == null)
            {
                districtEntity = new District()
                {
                    Name = district
                };
            }

            property.District = districtEntity;

            //Check PropertyType
            var propertyTypeEntity =
                this.dbContext.PropertyTypes.FirstOrDefault(x => x.Name.Trim() == propertyType.Trim());

            if (propertyTypeEntity == null)
            {
                propertyTypeEntity = new PropertyType()
                {
                    Name = propertyType,
                };
            }

            property.PropertyType = propertyTypeEntity;

            //Check BuildingType
            var buildingTypeEntity =
                this.dbContext.BuildingTypes.FirstOrDefault(x => x.Name.Trim() == buildingType.Trim());

            if (buildingTypeEntity == null)
            {
                buildingTypeEntity = new BuildingType()
                {
                    Name = buildingType,
                };
            }

            property.BuildingType = buildingTypeEntity;


            //Add the property to the Db and save changes
            this.dbContext.RealEstateProperties.Add(property);
            this.dbContext.SaveChanges();

            UpdateTags(property.Id);

        }

        public void UpdateTags(int propertyId)
        {
            var property = this.dbContext.RealEstateProperties.FirstOrDefault(x => x.Id == propertyId);

            property.RealEstatePropertyTags.Clear();

            if (property.BuildingYear.HasValue && property.BuildingYear < 1990)
            {
                property.RealEstatePropertyTags
                    .Add(new RealEstatePropertyTag
                    {
                        Tag = this.GetOrCreateTag("OldBuilding")
                    });
            }

            if (property.Size > 120)
            {
                property.RealEstatePropertyTags
                    .Add(new RealEstatePropertyTag
                    {
                        Tag = this.GetOrCreateTag("HugeApartment")
                    });
            }

            if (property.BuildingYear > 2018 && property.TotalNumberOfFloors > 5)
            {
                property.RealEstatePropertyTags
                    .Add(new RealEstatePropertyTag
                    {
                        Tag = this.GetOrCreateTag("HasParking")
                    });
            }

            if (property.Floor == property.TotalNumberOfFloors)
            {
                property.RealEstatePropertyTags
                    .Add(new RealEstatePropertyTag
                    {
                        Tag = this.GetOrCreateTag("LastFloor")
                    });
            }

            if (((double)property.Price / property.Size) < 800)
            {
                property.RealEstatePropertyTags
                    .Add(new RealEstatePropertyTag
                    {
                        Tag = this.GetOrCreateTag("CheepProperty")
                    });
            }

            if (((double)property.Price / property.Size) > 2000)
            {
                property.RealEstatePropertyTags
                    .Add(new RealEstatePropertyTag
                    {
                        Tag = this.GetOrCreateTag("ExpensiveProperty")
                    });
            }

            this.dbContext.SaveChanges();
        }

        public IEnumerable<PropertyViewModel> GetExactProperty(string district, int size, int? year, int price, string propertyType, int? floor)
        {
            var property = this.dbContext.RealEstateProperties.Where(x => x.District.Name == district
                          && x.Size == size
                          && x.BuildingYear == year
                          && x.Price == price
                          && x.PropertyType.Name == propertyType
                          && x.Floor == floor)
                .Select(MapToPropertyViewModel())
                .ToList();

            return property;
        }

        private Tag GetOrCreateTag(string tagName)
        {
            var tag = this.dbContext.Tags.FirstOrDefault(x => x.Name.Trim() == tagName.Trim());

            if (tag == null)
            {
                tag = new Tag()
                {
                    Name = tagName
                };
            }
            return tag;
        }

        public IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int MaxSize)
        {
            return this.dbContext.RealEstateProperties
                .Where(p => ((p.BuildingYear >= minYear) && (p.BuildingYear <= maxYear))
                            && ((p.Size >= minSize) && (p.Size <= MaxSize)))
                .Select(MapToPropertyViewModel())
                .OrderBy(x => x.BuildingYear)
                .ToList();
        }

        public IEnumerable<PropertyViewModel> SearchBuyPrice(int minPrice, int maxPrice)
        {
            return this.dbContext.RealEstateProperties
                .Where(p => (p.Price >= minPrice) && (p.Price <= maxPrice))
                .Select(MapToPropertyViewModel())
                .OrderBy(x => x.Price)
                .ToList();
        }

        private static Expression<Func<RealEstateProperty, PropertyViewModel>> MapToPropertyViewModel()
        {
            return x => new PropertyViewModel()
            {
                Price = x.Price,
                Floor = $"{x.Floor ?? 0}/{x.TotalNumberOfFloors ?? 0}",
                Size = x.Size,
                BuildingYear = x.BuildingYear,
                BuildingType = x.BuildingType.Name,
                District = x.District.Name,
                PropertyType = x.PropertyType.Name
            };
        }
    }
}
