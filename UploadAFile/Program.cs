using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Api.Files;
using Dropbox.Api.Sharing;
using Dropbox.Api;
using System.IO;

namespace UploadAFile
{
    /// <summary>
    /// This program will teach you how to upload a file to dropbox account and get its sharable download link.
    /// </summary>
    class Program
    {
        static string token = "token-here";
        static void Main(string[] args)
        {
            var task = Task.Run((Func<Task>)Program.Run);
            task.Wait();
            Console.ReadKey();
        }
        static async Task Run()
        {
            using (var dbx = new DropboxClient(token))
            {
                string file = @"C:\users\dell\Desktop\Dummy.txt";
                string folder = "/Public";
                string filename = "dummytextfile.txt";
                string url = "";
                using (var mem = new MemoryStream(File.ReadAllBytes(file)))
                {
                    var updated = dbx.Files.UploadAsync(folder + "/" + filename, WriteMode.Overwrite.Instance, body: mem);
                    updated.Wait();
                    var tx = dbx.Sharing.CreateSharedLinkWithSettingsAsync(folder + "/" + filename);
                    tx.Wait();
                    url = tx.Result.Url;
                }
                Console.Write(url);
            }
        }
    }
}
