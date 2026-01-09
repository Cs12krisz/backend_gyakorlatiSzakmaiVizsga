using Csiger_Krisztián_backend_vizsgaGyakorlat.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Csiger_Krisztián_backend_vizsgaGyakorlat.Services;
using Csiger_Krisztián_backend_vizsgaGyakorlat.Models.Dto;

namespace Csiger_Krisztián_backend_vizsgaGyakorlat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthor  _author;

        public AuthorsController(IAuthor author)
        {
            _author = author;
        }


        [HttpGet("feladat9/{authorname}")]
        public async Task<ActionResult> GetAuthorsBooks(string authorname)
        {
            try
            {
               var response = await _author.GetAuthorsBooks(authorname);
                if (response is FailedDto)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }

        }
    }
}
