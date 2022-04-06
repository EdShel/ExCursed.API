using ExCursed.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ExCursed.BLL.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly string filesFolder = "UploadedPhotos";

        public FileStorageService()
        {
        }

        /// <returns>Path to file or null if there is some error</returns>
        public async Task<string> SaveImageAsync(string identifier, IFormFile image)
        {
            if (image != null)
            {
                string fileExtension = Path.GetExtension(image.FileName);
                string fileName = Guid.NewGuid().ToString() + fileExtension;
                string filePath = Path.Combine(this.filesFolder, fileName);
                Directory.CreateDirectory(filesFolder);
                using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    var imageStream = image.OpenReadStream();
                    await imageStream.CopyToAsync(fs);
                }
                return filePath;
            }

            return null;
        }
    }
}
