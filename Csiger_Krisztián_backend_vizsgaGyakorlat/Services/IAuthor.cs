using Microsoft.AspNetCore.Mvc;

namespace Csiger_Krisztián_backend_vizsgaGyakorlat.Services
{
    public interface IAuthor
    {
        Task<object> GetAuthorsBooks(string authorName);

        Task<object> GetCountedAuthors();
    }
}
