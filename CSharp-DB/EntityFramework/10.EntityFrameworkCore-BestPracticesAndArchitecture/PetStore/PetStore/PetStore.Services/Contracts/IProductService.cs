using System;
using System.Collections.Generic;
using System.Text;
using PetStore.ServiceModels.InputModels;
using PetStore.ServiceModels.OutputModels;

namespace PetStore.Services.Contracts
{
    public interface IProductService
    {
        public void AddProduct(AddProductInputServiceModel model);
        public ICollection<ListAllProductsServiceModel> GetAllProducts();
        public ICollection<ListAllProductsByProductTypeServiceModel> ListAllProductType(string type);
        public ICollection<ListAllProductsByNameServiceModel> SearchProductByName(string searchStr, bool caseSensitive);
        public ProductDetailsServiceModel GetById(string id);
        public bool RemoveById(string id);
        public bool RemoveByName(string name);
        public void EditProduct(string id, EditProductInputServiceModel model);
    }
}
