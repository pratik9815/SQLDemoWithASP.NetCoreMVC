using SQLDemo.Models;

namespace SQLDemo.Repositories.ProductRepo
{
    public interface IProductRepository
    {
        List<ProductVm> GetProduct();
        int CreateProduct(CreateProduct product);
        ProductVm GetProductWithId(int? id);
        int EditProduct(ProductVm product);
        int DeleteProduct(int? id);
        ProductVm GetProductWithIdEdit(int? id);
    }
}
