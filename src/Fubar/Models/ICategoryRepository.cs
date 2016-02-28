using System.Collections.Generic;

namespace Fubar.Models
{
    public interface ICategoryRepository
    {
       IEnumerable<Category>  GetAllCategories();
       void AddCategory(Category newCategory);
       bool SaveAll();
    }
}