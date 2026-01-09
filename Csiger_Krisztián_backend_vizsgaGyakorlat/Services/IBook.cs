using Csiger_Krisztián_backend_vizsgaGyakorlat.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Csiger_Krisztián_backend_vizsgaGyakorlat.Services
{
    public interface IBook
    {
        Task<object> GetAllData();
        Task<object> PostDataWithAuthor(string uid, PostBookDto postBookDto);
    }
}
