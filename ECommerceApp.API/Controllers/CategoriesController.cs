using ECommerceApp.BL.DTOs.CategoryDTOs;
using ECommerceApp.BL.Managers.CategoryManager;
using ECommerceApp.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryManager _categorymanager;
        public CategoriesController(ICategoryManager categorymanager)
        {
            _categorymanager = categorymanager;
        }
        //This controller is responsible for all Categories end points
        //Getting End points
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetCategoryAsync(Guid id)
        {
            CategoryReadDto category =await _categorymanager.GetCategoryByIdAsync(id);
            if(category== null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpGet]
        [Route("GetByName")]
        public async Task<ActionResult> GetCategoryByName(string name)
        {
            CategoryReadDto myCat = await _categorymanager.GetCategoryByNameAsync(name);
            if(myCat==null)
            {
                return NotFound();
            }
            return Ok(myCat);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAllCategoryAsync()
        {
            IEnumerable< CategoryReadDto> category = await _categorymanager.GetAllCategoriesAsync();
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        //Adding new Category
        [HttpPost]
        public async Task<ActionResult> Add(CategoryAddDto model)
        {
            CategoryReadDto myCategory =await _categorymanager.AddNewCategoryAsync(model);
            if(myCategory==null)
            {
                return BadRequest();
            }
            return Ok(myCategory);
        }
        //Deleting an existing category
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            CategoryReadDto myCategory = _categorymanager.DeleteCategory(id);
            if (myCategory == null)
            {
                return BadRequest();
            }
            return Ok(myCategory);
        }

        //Updating an existing category
        [HttpPut]
        public ActionResult Update(CategoryUpdateDto model,Guid id)
        {
            CategoryReadDto myCategory = _categorymanager.UpdateCategory(model,id);
            if (myCategory == null)
            {
                return BadRequest();
            }
            return Ok(myCategory);
        }


    }
}
