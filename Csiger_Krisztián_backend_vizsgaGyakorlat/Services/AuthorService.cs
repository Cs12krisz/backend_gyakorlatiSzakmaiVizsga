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
                    return authorBooks;
                }

                return new FailedDto();

            }
            catch (Exception ex)
            {
                return new FailedDto(ex.Message);
            }
        }
    }
}
