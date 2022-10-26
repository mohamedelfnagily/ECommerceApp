using ECommerceApp.BL.DTOs.CategoryDTOs;
using ECommerceApp.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.BL.Managers.CategoryManager
{
    public interface ICategoryManager
    {
        //This interface is responsible for all the methods which will be exposed to the categories controller
        //This interface have all the signateure of the methods that will be used
        //Getting Section:
        CategoryReadDto GetCategoryById(Guid id);
        Task<CategoryReadDto> GetCategoryByIdAsync(Guid id);
        CategoryReadDto GetCategoryByName(string Name);
        Task<CategoryReadDto> GetCategoryByNameAsync(string Name);
        IEnumerable<CategoryReadDto> GetAllCategories();
        Task<IEnumerable<CategoryReadDto>> GetAllCategoriesAsync();
        //Adding Section
        CategoryReadDto AddNewCategory(CategoryAddDto model);
        Task<CategoryReadDto> AddNewCategoryAsync(CategoryAddDto model);
        //Deleting Section
        CategoryReadDto DeleteCategory(Guid id);
        //Updating Section
        CategoryReadDto UpdateCategory(CategoryUpdateDto model, Guid id);



    }
}
