using AutoMapper;
using ECommerceApp.BL.DTOs.CategoryDTOs;
using ECommerceApp.DAL.Data.Models;
using ECommerceApp.DAL.Repository.NonGeneric.Category_NonGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.BL.Managers.CategoryManager
{
    public class CategoryManager:ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryRepository _categoryRepo,IMapper mapper)
        {
            _categoryRepository = _categoryRepo;
            _mapper = mapper;
        }
        //Getting section implementation
        public CategoryReadDto GetCategoryById(Guid id)
        {
            Category myCategory = _categoryRepository.GetById(id);
            if(myCategory == null)
            {
                return null;
            }
            CategoryReadDto categ = _mapper.Map<CategoryReadDto>(myCategory);
            return categ;
        }

        public async Task<CategoryReadDto> GetCategoryByIdAsync(Guid id)
        {
            Category myCategory =await _categoryRepository.GetByIdAsync(id);
            if (myCategory == null)
            {
                return null;
            }
            CategoryReadDto categ = _mapper.Map<CategoryReadDto>(myCategory);
            return categ;
        }
        public CategoryReadDto GetCategoryByName(string Name)
        {
            Category myCategory = _categoryRepository.GetCategoryByName(Name);
            if (myCategory == null)
            {
                return null;
            }
            CategoryReadDto categ = _mapper.Map<CategoryReadDto>(myCategory);
            return categ;
        }

        public async Task<CategoryReadDto> GetCategoryByNameAsync(string Name)
        {
            Category myCategory = await _categoryRepository.GetCategoryByNameAsync(Name);
            if (myCategory == null)
            {
                return null;
            }
            CategoryReadDto categ = _mapper.Map<CategoryReadDto>(myCategory);
            return categ;
        }

        public IEnumerable<CategoryReadDto> GetAllCategories()
        {
            IEnumerable<Category> myCategories =  _categoryRepository.GetAll();
            if(myCategories == null)
            {
                return null;
            }
            IEnumerable<CategoryReadDto> myCategs = _mapper.Map<IEnumerable<CategoryReadDto>>(myCategories);
            return myCategs;
        }

        public async Task<IEnumerable<CategoryReadDto>> GetAllCategoriesAsync()
        {
            IEnumerable<Category> myCategories =await _categoryRepository.GetAllAsync();
            if (myCategories == null)
            {
                return null;
            }
            IEnumerable<CategoryReadDto> myCategs = _mapper.Map<IEnumerable<CategoryReadDto>>(myCategories);
            return myCategs;
        }
        //Adding section implementation
        public CategoryReadDto AddNewCategory(CategoryAddDto model)
        {
            Category newCategory = new Category();
            newCategory = _mapper.Map<Category>(model);
            if(newCategory==null)
            {
                return null;
            }
            newCategory.Id = Guid.NewGuid();
            _categoryRepository.Add(newCategory);
            _categoryRepository.Save();
            CategoryReadDto AddedCategory = _mapper.Map<CategoryReadDto>(newCategory);
            if(AddedCategory==null)
            {
                return null;
            }
            return AddedCategory;
            
        }

        public async Task<CategoryReadDto> AddNewCategoryAsync(CategoryAddDto model)
        {
            Category newCategory = new Category();
            newCategory = _mapper.Map<Category>(model);
            if (newCategory == null)
            {
                return null;
            }
            newCategory.Id = Guid.NewGuid();
            await _categoryRepository.AddAsync(newCategory);
            _categoryRepository.Save();
            CategoryReadDto AddedCategory = _mapper.Map<CategoryReadDto>(newCategory);
            if (AddedCategory == null)
            {
                return null;
            }
            return AddedCategory;
        }
        //Deleting Section
        public CategoryReadDto DeleteCategory(Guid id)
        {
            Category deletedCategory = _categoryRepository.Delete(id);
            if(deletedCategory==null)
            {
                return null;
            }
            _categoryRepository.Save();
            CategoryReadDto category = _mapper.Map<CategoryReadDto>(deletedCategory);
            return category;
        }

        //Updating section
        public CategoryReadDto UpdateCategory(CategoryUpdateDto model, Guid id)
        {
            Category category = _categoryRepository.GetById(id);
            _mapper.Map(model,category);
            if(category==null)
            {
                return null;
            }
            _categoryRepository.Save();
            CategoryReadDto UpdatedCategory = _mapper.Map<CategoryReadDto>(category);
            return UpdatedCategory;
        }


    }
}
