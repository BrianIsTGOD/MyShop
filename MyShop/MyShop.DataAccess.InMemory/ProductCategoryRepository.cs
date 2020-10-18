using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public  class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {

            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }
        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);

        }

        public void Update(ProductCategory productcat)
        {
            ProductCategory productcatToUpdate = productCategories.Find(p => p.Id == productcat.Id);

            if (productcatToUpdate != null)
            {

                productcatToUpdate = productcat;
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory productcat = productCategories.Find(p => p.Id == Id);

            if (productcat != null)
            {

                return productcat;
            }
            else
            {
                throw new Exception("Product Category not found");
            }

        }


        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productcatToDelete = productCategories.Find(p => p.Id == Id);

            if (productcatToDelete != null)
            {
                productCategories.Remove(productcatToDelete);

            }
            else
            {
                throw new Exception("Product Category not found");
            }

        }
    }
}
