using Csiger_Krisztián_backend_vizsgaGyakorlat.Models.Dto;
using Csiger_Krisztián_backend_vizsgaGyakorlat.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Csiger_Krisztián_backend_vizsgaGyakorlat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBook _book;

        public BooksController(IBook book)
        {
            _book = book;
        }

        [HttpGet("feladat10")]
        public async Task<ActionResult> GetAllData()
        {
            try
            {
                var response = await _book.GetAllData();
                if (response is FailedDto)
                {
                    var result = response as FailedDto;
                    return BadRequest(result.Message);
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
