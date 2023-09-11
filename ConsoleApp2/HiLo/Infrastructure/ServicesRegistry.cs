using ConsoleApp2.HiLo.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.HiLo.Infrastructure;
public static class ServicesRegistry
{
    public static void AddTabularHiLo(this IServiceCollection services)
    {
        new EntityFrameworkRelationalServicesBuilder(services)
            .TryAdd<IConventionSetPlugin, HiLoConventionSetPlugin>();
    }
}
