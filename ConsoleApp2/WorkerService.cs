using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp2;
internal class WorkerService : IHostedService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public WorkerService(IServiceScopeFactory scopeFactory)
    {

        _scopeFactory = scopeFactory;
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<BloggingContext>();
        context.Blogs.Add(new Blog { Url = $"https://{Guid.NewGuid:n}", });

        await context.SaveChangesAsync();
        var model = context.GetService<IRelationalModel>();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {

    }
}
