using Csiger_Krisztián_backend_vizsgaGyakorlat.Models;
using Csiger_Krisztián_backend_vizsgaGyakorlat.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Csiger_Krisztián_backend_vizsgaGyakorlat.Services
{
    public class CategoryService : ICategory
    {
        private readonly LibrarydbContext _context;

        public CategoryService(LibrarydbContext context)
        {
            _context = context;
        }

        public async Task<object> GetAllCategoriesBooks()
        {
            try
            {
                var categoriesBooks = _context.Categories
                    .Include(x => x.Books)
                    .Select(c => new
                    {
                        c.CategoryId,
                        c.CategoryName,
                        Books = c.Books.Select(b => new
                        {
                            b.BookId,
                            b.Title,
                            b.PublishDate,
                            b.AuthorId,
                            b.CategoryId
                        })
                    })
                    ;
                return categoriesBooks;
            }
            catch (Exception ex)
            {
                return new FailedDto(ex.Message);
            }
        }
    }
}
