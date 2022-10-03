using AppReceitas.Application.Interfaces;
using ImageProcessor;
using ImageProcessor.Plugins.WebP.Imaging.Formats;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppReceitas.Application.Services
{
    public class ImageService : IImageService
    {
        public string UploadFile(IFormFile file)
        {
            var urlFile = Guid.NewGuid() + ".webp";

            using (var webPFileStream = new FileStream(Path.Combine("Medias/Imagens", urlFile), FileMode.Create))
            {
                using (ImageFactory imageFactory = new ImageFactory(preserveExifData: false))
                {
                    imageFactory.Load(file.OpenReadStream())
                                 .Format(new WebPFormat())
                                 .Quality(100)
                                 .Save(webPFileStream);
                }
            }
            return $"C:/Users/bruna.oliveira/DEV/App-receitas/src/Server/AppReceitas.Api/Medias/Imagens/{urlFile}";
        }
    }
}
