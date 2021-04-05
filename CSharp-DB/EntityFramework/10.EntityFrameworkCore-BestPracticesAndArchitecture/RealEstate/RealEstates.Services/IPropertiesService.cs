using System;
using System.Collections.Generic;
using System.Text;
using RealEstates.Services.Models;

namespace RealEstates.Services
{
    //This interface implements our main functions of the app Create, Search, SearchBuyPrice
    public interface IPropertiesService
    {
        void Create(string district, int size, int? year, int price,
                    string propertyType, string buildingType, int? floor, int? maxFloors);

        void UpdateTags(int propertyId);

        IEnumerable<PropertyViewModel> GetExactProperty(string district, int size, int? year, int price, string propertyType, int? floor);
        IEnumerable<PropertyViewModel> Search(int minYear, int maxYear, int minSize, int MaxSize);
        IEnumerable<PropertyViewModel> SearchBuyPrice(int minPrice, int maxPrice);
    }
}
