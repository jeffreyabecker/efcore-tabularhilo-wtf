using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        context.Blogs.Add(new Blog { Url = "https://a.b.c.d", CreatedBy = "", });
        await context.SaveChangesAsync();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {

    }
}
