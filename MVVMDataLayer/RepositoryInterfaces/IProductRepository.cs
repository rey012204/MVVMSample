using System.Collections.Generic;
using MVVMEntityLayer;

namespace MVVMDataLayer
{
    public interface IProductRepository
    {
        List<Product> Get();
        List<Product> Search(ProductSearch entity);
        Product Get(int id);
        Product CreateEmpty();
        Product Add(Product entity);
        Product Update(Product entity);
        bool Delete(int id);
    }
}
