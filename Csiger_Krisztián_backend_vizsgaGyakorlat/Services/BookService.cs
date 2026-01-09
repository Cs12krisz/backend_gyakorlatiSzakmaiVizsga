using Csiger_Krisztián_backend_vizsgaGyakorlat.Models;
using Csiger_Krisztián_backend_vizsgaGyakorlat.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Csiger_Krisztián_backend_vizsgaGyakorlat.Services
{
    public class BookService : IBook
    {
        private readonly LibrarydbContext _context;

        public BookService(LibrarydbContext context)
        {
            _context = context;
        }

        public async Task<object> GetAllData()
        {
            try
            {
                var books = await _context.Books.Select(b => new 
                {
                    b.BookId,
                    b.Title,
                    b.PublishDate,
                    b.AuthorId,
                    b.CategoryId
                }).ToArrayAsync();
                return books;
            }
            catch (Exception ex)
            {
                return new FailedDto(ex.Message);
            }
        }
    }
}
