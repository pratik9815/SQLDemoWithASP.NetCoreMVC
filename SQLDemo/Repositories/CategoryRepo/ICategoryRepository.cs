using SQLDemo.Models;

namespace SQLDemo.Repositories.CategoryRepo
{
    public interface ICategoryRepository
    {
        List<CategoryVm> GetCategories();
        int CreateCategory(CreateCategory category);
        CategoryVm GetCategoryWithId(int? id);
        int EditCategory(CategoryVm category);
        int DeleteCategory(int? id);
    }

}
