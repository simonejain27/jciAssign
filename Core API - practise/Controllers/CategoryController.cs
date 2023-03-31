using CategoryService.Dal;
using CategoryService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_API___practise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataAccess dataAccess;
        //dependency injection
        public CategoryController(DataAccess dbAccess)  //contructor injection 
        {
            dataAccess = dbAccess;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var response = dataAccess.GetAllCategories();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = dataAccess.GetCategory(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            var response = dataAccess.CreateCategory(category);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Put(int id, Category category)
        {
            var response = dataAccess.UpdateCategory(id, category);
            return Ok(response);    
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
        var response =  dataAccess.DeleteCategory(id);
        return Ok(response);
        }

    }
}
