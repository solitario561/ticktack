using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using frontend.Extensiones;
using System.Net;
using System.Text;

namespace frontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            string userName = "11207515";
            string pass = "60-dayfreetrial";

            string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userName}:{pass}"));

			/*builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://carlosluna-001-site1.ltempurl.com") });*/
			builder.Services.AddScoped(sp =>
            {
                var client = new HttpClient
                {
					BaseAddress = new Uri("http://carlosluna-001-site1.ltempurl.com")
				};
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);

                return client;
            });


			builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
            builder.Services.AddAuthorizationCore();

            await builder.Build().RunAsync();
        }
    }
}
