using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Juan_ShoesStore.Extensions
{
    public static class FileManager
    {
        /// <summary>
        /// Bu extension metod faylin content type'ni check edir:
        /// eger faylin type'i arqument kimi gonderilen type'la eynidirse true,
        /// eks halda false deyer qaytarir.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static bool CheckFileContentType(this IFormFile file, string contentType)
        {
            return file.ContentType == contentType;
        }

        /// <summary>
        /// Bu extension metod faylin olcusunu check edir:
        /// eger faylin olcusu arqument kimi gonderilen olcuden (max size) boyukdurse false,
        /// eks halda true deyer qaytarir.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="maxSize"></param>
        /// <returns></returns>
        public static bool CheckFileSize(this IFormFile file, double maxSize)
        {
            return Math.Round((double)file.Length / 1024) <= maxSize;
        }

        /// <summary>
        /// Bu extension metod yeni yuklenilen fayli sechilmish folder'e upload edir (environment'i nezere alaraq)
        /// ve sonda database-e set etmek uchun hemin faylin adini qaytarir.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="env"></param>
        /// <param name="folders"></param>
        /// <returns></returns>
        public static string CreateFile(this IFormFile file, IWebHostEnvironment env, params string[] folders)
        {
            string fileName = $"{Guid.NewGuid()}_{DateTime.UtcNow.AddHours(4).ToString("yyyyMMddHHmmssffff")}_{file.FileName}";

            string path = env.WebRootPath;

            foreach (string folder in folders)
            {
                path = Path.Combine(path, folder);
            }

            path = Path.Combine(path, fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return fileName;
        }
    }
}
