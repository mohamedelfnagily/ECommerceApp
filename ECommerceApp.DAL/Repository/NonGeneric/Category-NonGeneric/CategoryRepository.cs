using ECommerceApp.DAL.Data.Context;
using ECommerceApp.DAL.Data.Models;
using ECommerceApp.DAL.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.DAL.Repository.NonGeneric.Category_NonGeneric
{
    public class CategoryRepository:BaseRepository<Category>,ICategoryRepository
    {
        //In this class we are implementing all the methods of categories
        private readonly ApplicationDbContext _Context;
        public CategoryRepository(ApplicationDbContext context):base(context)
        {
            _Context = context;
        }
        //Getting the category including all the products related to this category synchronously
        public Category GetCategoryWithProducts(Guid id)
        {
            return _Context.Categories.Include(e => e.products).FirstOrDefault(e => e.Id == id);
        }
        //Getting the category including all the products related to this category Asynchronously

        public async Task<Category> GetCategoryWithProductsAsync(Guid id)
        {
            return await _Context.Categories.Include(e => e.products).FirstOrDefaultAsync(e => e.Id == id);
        }
        //Getting the category by it's name synchronously

        public Category GetCategoryByName(string Name)
        {
            return  _Context.Categories.FirstOrDefault(e => e.Name == Name);
        }
        //Getting the category by it's name asynchronously

        public async Task<Category> GetCategoryByNameAsync(string Name)
        {
            Category myCategory = await _Context.Categories.FirstOrDefaultAsync(e => e.Name == Name);
            return myCategory;
        }
    }
}
