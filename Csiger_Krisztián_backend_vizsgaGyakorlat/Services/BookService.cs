using Csiger_Krisztián_backend_vizsgaGyakorlat.Models;
using Csiger_Krisztián_backend_vizsgaGyakorlat.Models.Dto;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<object> PostDataWithAuthor(string uid, PostBookDto postBookDto)
        {
            try
            {
                string identity = "FKB3F4FEA09CE43C";
                if (uid != identity)
                {
                    return new FailedDto("Nincs jogosultsága új könyv felvételéhez!");
                }

              
                var newBook = new Book() 
                { 
                        BookId = postBookDto.BookId,
                        Title = postBookDto.Title,
                        PublishDate = postBookDto.PublishDate,
                        AuthorId = postBookDto.AuthorId,
                        CategoryId = postBookDto.CategoryId,
                };

                await _context.Books.AddAsync(newBook);
                await _context.SaveChangesAsync();
                return newBook;
                
            }
            catch (Exception ex)
            {
                return new FailedDto(ex.Message);
            }
        }
    }
}
