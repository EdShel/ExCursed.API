using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace ExCursed.WebAPI.Controllers
{
    [ApiController]
    [Route("file")]
    public class FileController : ControllerBase
    {
        [HttpGet("{*filePath}")]
        public FileResult GetFile(string filePath)
        {
            return PhysicalFile(Path.GetFullPath(filePath), GetMime(filePath));
        }

        internal static string GetFileLink(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                return null;
            }
            return "https://localhost:5001/file/" + file;
        }

        private static string GetMime(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            switch (extension)
            {
                case ".png": return "image/png";
                case ".jpg": return "image/jpeg";
                case ".jpeg": return "image/jpeg";
                case ".txt": return "text/plain";
                default: return "application/octet-stream";
            }
        }
    }
}
