using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp2;

internal class Program
{
    static void Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddHostedService<WorkerService>();

        builder.Services.AddDbContext<BloggingContext>();

        IHost host = builder.Build();
        host.Run();
    }
}
