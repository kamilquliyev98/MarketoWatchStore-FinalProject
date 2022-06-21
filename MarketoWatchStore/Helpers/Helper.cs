using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Juan_ShoesStore.Helpers
{
    public class Helper
    {
        /// <summary>
        /// Bu metod verilen path'da yerleshen (environment nezere alinmaqla) file'i silir.
        /// </summary>
        /// <param name="env"></param>
        /// <param name="fileName"></param>
        /// <param name="folders"></param>
        public static void DeleteFile(IWebHostEnvironment env, string fileName, params string[] folders)
        {
            string path = env.WebRootPath;

            foreach (string folder in folders)
            {
                path = Path.Combine(path, folder);
            }

            path = Path.Combine(path, fileName);

            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
