using Csiger_Krisztián_backend_vizsgaGyakorlat.Models;
using Csiger_Krisztián_backend_vizsgaGyakorlat.Models.Dto;
using Csiger_Krisztián_backend_vizsgaGyakorlat.Services;
using K4os.Compression.LZ4.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("feladat12")]
        public async Task<ActionResult> GetCountedAuthors()
        {
            try
            {
                var response = await _author.GetCountedAuthors();
                if (response is FailedDto)
                {
                    return BadRequest("Nem lehet csatlakozni az adatbázishoz!");
                }
                return Ok($"Szerzők száma: {response}");
            }
            catch (Exception ex)
            {

                return BadRequest("Nem lehet csatlakozni az adatbázishoz!");
            }

        }
    }
}
