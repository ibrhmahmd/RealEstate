using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PresentationLayer.helper
{
    public static class UploadFile
    {
        public static string UploadImage(string FolderName, IFormFile File)
        {
            try
            {
                string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "properties", FolderName);

                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }

                string FileName = Guid.NewGuid() + Path.GetFileName(File.FileName);
                string FinalPath = Path.Combine(FolderPath, FileName);

                using (var Stream = new FileStream(FinalPath, FileMode.Create))
                {
                    File.CopyTo(Stream);
                }

                return FileName;
            }
            catch (Exception ex)
            {
                // Log or handle the error
                return "Error: " + ex.Message;
            }
        }




    }
}