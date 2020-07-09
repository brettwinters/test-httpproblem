using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorApp1.Shared;
using Fluxor;

namespace BlazorApp1
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped<HttpProcessingDelegatingHandler>();

            builder.Services
                .AddHttpClient("local", c => c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<HttpProcessingDelegatingHandler>();

            builder.Services.AddFluxor(options => options
                .ScanAssemblies(typeof(Program).Assembly)
                .UseRouting()
                .UseReduxDevTools()
            );

            await builder.Build().RunAsync();
		}
	}
}
