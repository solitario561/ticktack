using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using frontend.Extensiones;

namespace frontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5098") });

            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
            builder.Services.AddAuthorizationCore();

            await builder.Build().RunAsync();
        }
    }
}
