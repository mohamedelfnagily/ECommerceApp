using ECommerceApp.DAL.Data.Models;
using ECommerceApp.DAL.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DAL.Repository.NonGeneric.Category_NonGeneric
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        //This interface is responsible for the methods reagrding the categories
        
        Category GetCategoryWithProducts(Guid id);
        Task<Category> GetCategoryWithProductsAsync(Guid id);
        Category GetCategoryByName(string Name);
        Task<Category> GetCategoryByNameAsync(string Name);
    }
}
