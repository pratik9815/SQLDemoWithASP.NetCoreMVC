
using Dapper;
using Microsoft.AspNetCore.Mvc;
using SQLDemo.Models;
using SQLDemo.Util;
using System.Data.Common;

namespace SQLDemo.Repositories.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository   
    {

        RepositoryDao connection;
        public CategoryRepository()
        {
            connection = new RepositoryDao();
        }
        public List<CategoryVm> GetCategories()
        {
            string sql = "select *from category";
            
            var category = connection.LoadSQLDataList<CategoryVm>(sql);
            return category;
        }
        public int CreateCategory(CreateCategory category)
        {
            //Using Dapper
            //DynamicParameters dynamicParameters = new DynamicParameters();  
            //dynamicParameters.Add("@categoryname", category.CategoryName);
            //dynamicParameters.Add("@description", category.Description);
            //string sql = "insert into category (CategoryName,Description) values (@categoryname,@description)";
            string sql = $"insert into category (CategoryName,Description) values ('{category.CategoryName}','{category.Description}')";
            var result = connection.RunSQL(sql);
            return result;
        }

        public CategoryVm GetCategoryWithId(int? id)
        {
            string sql = $"select *from category where id = '{id}'";
            var categoryDetails = connection.LoadSQLDataSingle<CategoryVm>(sql);
            return categoryDetails;
        }

        public int EditCategory(CategoryVm category)
        {
            string sql = $"update category set categoryname = '{category.CategoryName}', description = '{category.Description}' where id = '{category.Id}'";
            var result = connection.RunSQL(sql);
            return result;
        }
        public int DeleteCategory(int? id)
        {
            string sql = $"delete from category where id = '{id}'";
            var result = connection.RunSQL(sql);
            return result;
        }
    }
}
