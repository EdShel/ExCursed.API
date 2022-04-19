using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ExCursed.BLL.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(string identifier, IFormFile image);
    }
}
