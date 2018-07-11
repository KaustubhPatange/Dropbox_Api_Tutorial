using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Api;
using System.IO;

namespace DownloadAFile
{
    /// <summary>
    /// This program will teach you how to download files from dropbox account
    /// </summary>
    class Program
    {
        static string token = "token-here";
        static void Main(string[] args)
        {
            var task = Task.Run((Func<Task>)Program.Run);
            task.Wait();
        }
        static async Task Run()
        {
            using (var dbx = new DropboxClient(token))
            {
                string folder = "";
                string file = "full-file-name";
                using (var response = await dbx.Files.DownloadAsync(folder + "/" + file))
                {
                    var s = response.GetContentAsByteArrayAsync();
                    s.Wait();
                    var d = s.Result;
                    File.WriteAllBytes(file, d);
                }
            }
        }
    }
}
