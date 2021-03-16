using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.ServiceModels.OutputModels;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.InputModels;
using PetStore.Services.Contracts;

namespace PetStore.Services
{
    public class ProductService : IProductService

    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public ProductService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddProduct(AddProductInputServiceModel model)
        {
            try
            {
                Product product = this.mapper.Map<Product>(model);
                this.dbContext.Products.Add(product);
                this.dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }
            
        }

        public ICollection<ListAllProductsServiceModel> GetAllProducts()
        {
            var products = this.dbContext.Products
                    .ProjectTo<ListAllProductsServiceModel>(this.mapper.ConfigurationProvider)
                    .ToList();

            return products;
        }

        public ICollection<ListAllProductsByProductTypeServiceModel> ListAllProductType(string type)
        {
            ProductType productType;
            bool hasParsed = Enum.TryParse<ProductType>(type, true, out productType);

            if (!hasParsed)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }

            var productsServiceModels = this.dbContext.Products
                .Where(x => x.ProductType == productType)
                .ProjectTo<ListAllProductsByProductTypeServiceModel>
                    (this.mapper.ConfigurationProvider)
                .ToList();

            return productsServiceModels;
        }

        public ICollection<ListAllProductsByNameServiceModel> SearchProductByName(string searchStr, bool caseSensitive)
        {
            ICollection<ListAllProductsByNameServiceModel> products;
            if (caseSensitive == true)
            {
                products = this.dbContext.Products
                    .Where(x => x.Name.Contains(searchStr))
                    .ProjectTo<ListAllProductsByNameServiceModel>
                        (mapper.ConfigurationProvider)
                    .ToList();
            }
            else
            {
                products = this.dbContext.Products
                    .Where(x => x.Name.ToLower().Contains(searchStr.ToLower())) 
                    .ProjectTo<ListAllProductsByNameServiceModel>
                        (mapper.ConfigurationProvider)
                    .ToList();
            }

            return products;
        }

        public ProductDetailsServiceModel GetById(string id)
        {
            var product = this.dbContext.Products.FirstOrDefault(x=> x.Id == id);

            if (product == null)
            {
                throw new ArgumentException(ExceptionMessages.ProductNotFound);
            }

            var serviceModel = this.mapper.Map<ProductDetailsServiceModel>(product);

            return serviceModel;
        }

        public bool RemoveById(string id)
        {
            var productToRemove = this.dbContext.Products.FirstOrDefault(x => x.Id == id);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.ProductNotFound);
            }

            this.dbContext.Products.Remove(productToRemove);
            int rowsAffected = this.dbContext.SaveChanges();

            bool wasDeleted = rowsAffected == 1;

            return wasDeleted;
        }

        public bool RemoveByName(string name)
        {
            var productToRemove = this.dbContext.Products.FirstOrDefault(x => x.Name == name);

            if (productToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.ProductNotFound);
            }

            this.dbContext.Products.Remove(productToRemove);
            int rowsAffected = this.dbContext.SaveChanges();

            bool wasDeleted = rowsAffected == 1;

            return wasDeleted;
        }

        public void EditProduct(string id, EditProductInputServiceModel model)
        {
            try
            {
                var product = this.mapper.Map<Product>(model);
                var productToUpdate = this.dbContext.Products.FirstOrDefault(x => x.Id == id);

                if (productToUpdate == null)
                {
                    throw new ArgumentException(ExceptionMessages.ProductNotFound);
                }

                productToUpdate.Name = product.Name;
                productToUpdate.ProductType = product.ProductType;
                productToUpdate.Price = product.Price;

                this.dbContext.SaveChanges();

            }
            catch (ArgumentException ae)
            {
                throw ae;
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.InvalidProductType);
            }
        }
    }
}
