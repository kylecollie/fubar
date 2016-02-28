using System.Collections.Generic;

namespace Fubar.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product>  GetAllProducts();
        void AddProduct(Product newProduct);
        bool SaveAll();
    }
}