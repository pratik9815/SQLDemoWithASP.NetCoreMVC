using SQLDemo.Models;
using SQLDemo.Util;

namespace SQLDemo.Repositories.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        RepositoryDao connection;
        public ProductRepository()
        {
            connection = new RepositoryDao();
        }
        public int CreateProduct(CreateProduct product)
        {
            string sql = $"insert into product (Name , Price, quantity , Description , CategoryId) values ('{product.Name}',{product.Price},{product.Quantity},'{product.Description}','{product.CategoryId}')";
            var result = connection.RunSQL(sql);    
            return result;
        }

        public int DeleteProduct(int? id)
        {
            string sql = $"delete from product where id = '{id}'";
            var result = connection.RunSQL(sql);    
            return result;
        }

        public int EditProduct(ProductVm product)
        {
            string sql = $"update product set name = '{product.Name}', description = '{product.Description}', price = '{product.Price}', quantity = '{product.Quantity}', categoryId='{product.CategoryId}' where id = '{product.Id}'";
            var result = connection.RunSQL(sql);
            return result;
        }

        public List<ProductVm> GetProduct()
        {
            string sql = "select *from Product";
            var products = connection.LoadSQLDataList<ProductVm>(sql);
            return products;
        }

        public ProductVm GetProductWithId(int? id)
        {
            string sql = $"select p.id, p.name, p.price , p.description , p.quantity , c.categoryname from product as p join category as c on c.id = p.categoryId where p.id = '{id}'";
            //string sql = $"select *from product where id = '{id}'";
            ProductVm product = connection.LoadSQLDataSingle<ProductVm>(sql);
            return product;
        }
       
        public ProductVm GetProductWithIdEdit(int? id)
        {
            string sql = $"select *from product where id = {id}";
            ProductVm product = connection.LoadSQLDataSingle<ProductVm>(sql);
            return product;
        }


    }
}
