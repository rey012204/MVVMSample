using System;
using System.Collections.Generic;
using System.Linq;
using MVVMEntityLayer;

namespace MVVMDataLayer
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(AdvWorksDbContext context)
        {
            DbContext = context;
        }

        private AdvWorksDbContext DbContext { get; set; }

        public List<Product> Get()
        {
            return DbContext.Products.ToList();
        }
        public List<Product> Search(ProductSearch entity)
        {
            List<Product> ret;

            // Perform Searching  
            if(entity == null)
                ret = DbContext.Products.ToList();
            else
                ret = DbContext.Products.Where(p => (entity.Name == null || p.Name.StartsWith(entity.Name)) && (entity.ListPrice == null || p.ListPrice >= entity.ListPrice)).ToList();
            return ret;
        }
        public Product Get(int id)
        {
            return DbContext.Products.FirstOrDefault(p => p.ProductID == id);
        }
        public virtual Product CreateEmpty()
        {
            return new Product
            {
                ProductID = null,
                Name = string.Empty,
                ProductNumber = string.Empty,
                Color = string.Empty,
                StandardCost = 1,
                ListPrice = 2,
                Size = string.Empty,
                Weight = 0M,
                SellStartDate = DateTime.Now,
                SellEndDate = null,
                DiscontinuedDate = null,
            };
        }
        public virtual Product Add(Product entity)
        {
            // Add new entity to Products DbSet  
            DbContext.Products.Add(entity);

            // Save changes in database  
            DbContext.SaveChanges();

            return entity;
        }
        public virtual Product Update(Product entity)
        {
            // Update entity in Products DbSet  
            DbContext.Products.Update(entity);

            // Save changes in database  
            DbContext.SaveChanges();

            return entity;
        }
        public virtual bool Delete(int id)
        {
            // Locate entity to delete  
            DbContext.Products.Remove(DbContext.Products.Find(id));

            // Save changes in database  
            DbContext.SaveChanges();

            return true;
        }


    }
}
