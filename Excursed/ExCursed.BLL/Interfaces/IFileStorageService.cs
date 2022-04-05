using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ExCursed.BLL.Interfaces
{
    public interface IFileStorageService
    {
        Task<string> SaveImageAsync(string identifier, IFormFile image);
    }
}
