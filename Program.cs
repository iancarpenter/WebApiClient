using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;

namespace WebApiClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            var repositories = await ProcessRepositories();

            foreach(var repo in repositories)
            {
                System.Console.WriteLine(repo.Name);
                System.Console.WriteLine(repo.Description);
                System.Console.WriteLine(repo.GitHubHomeUrl);
                System.Console.WriteLine(repo.Homepage);
                System.Console.WriteLine(repo.Watchers);
                System.Console.WriteLine(repo.lastPush);
                System.Console.WriteLine();
            }
        }

        private static async Task<List<Repository>> ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            
            // var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var respositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);

            return respositories;            
        }
    }
}
