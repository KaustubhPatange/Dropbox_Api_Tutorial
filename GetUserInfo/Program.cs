using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dropbox.Api;

namespace Tutorial
{
    /// <summary>
    /// This program teaches you how to Get some basic user information from its token.
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
                var id = await dbx.Users.GetCurrentAccountAsync();
                Console.WriteLine($"Name: {id.Name.DisplayName}\nEmail: {id.Email}\nCountry: {id.Country}");
                Console.ReadKey();
            }
        }

    }
}
