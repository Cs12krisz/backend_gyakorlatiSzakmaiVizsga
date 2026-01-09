using Csiger_Krisztián_backend_vizsgaGyakorlat.Models;
using Csiger_Krisztián_backend_vizsgaGyakorlat.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Csiger_Krisztián_backend_vizsgaGyakorlat.Services
{
    public class AuthorService : IAuthor
    {
        private readonly LibrarydbContext _context;

        public AuthorService(LibrarydbContext context)
        {
            _context = context;
        }

        public async Task<object> GetAuthorsBooks(string authorName)
        {
            try
            {
                var authorBooks = _context.Authors
                    .Include(au => au.Books)
                    .Where(au => au.AuthorName == authorName);
                    
                if (authorBooks != null)
                {
                    var valasz = authorBooks.Select(au => new
                    {
                        au.AuthorId,
                        au.AuthorName,
                        Books = au.Books.Select(b => new
                        {
                            b.BookId,
                            b.Title,
                            b.PublishDate,
                            b.AuthorId,
                            b.CategoryId
                        })
                    });
                    return valasz;
                }

                return new FailedDto();

            }
            catch (Exception ex)
            {
                return new FailedDto(ex.Message);
            }
        }

        public async Task<object> GetCountedAuthors()
        {
            try
            {
                var authorsCount = _context.Authors.Count();
                return authorsCount;
            }
            catch (Exception ex)
            {
                return new FailedDto(ex.Message);
            }
        }
    }
}
