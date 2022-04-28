using dungDDL.IRepositories;
using dungDDL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace dungAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            var categories = await _categoryRepo.GetAll();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult> AddCategory(CategoryVM model)
        {
            if (!ModelState.IsValid)
            {
                var result = new HandleState(false, "Model is not Valid");
                return Ok(result);
            }
            var categories = await _categoryRepo.Add(model);
            return Ok(categories);
        }

    }
}