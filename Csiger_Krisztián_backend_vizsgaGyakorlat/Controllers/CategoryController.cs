using Csiger_Krisztián_backend_vizsgaGyakorlat.Models.Dto;
using Csiger_Krisztián_backend_vizsgaGyakorlat.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Csiger_Krisztián_backend_vizsgaGyakorlat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _category;

        public CategoryController(ICategory category) 
        {
            _category = category;
        }

        [HttpGet("feladat11")]
        public async Task<ActionResult> GetAllCategoriesBooks() 
        {
            try
            {
                var response = await _category.GetAllCategoriesBooks();
                if (response is FailedDto)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
