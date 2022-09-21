using Gevangenis.Models.Entity;
using Gevangenis.Repositories;

namespace Gevangenis.Web;

public static class StartupExtensions
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddTransient<IRepository<Prison>,Repository<Prison>>();
        services.AddTransient<IRepository<Cell>, Repository<Cell>>();
        services.AddTransient<IRepository<Prisoner>, Repository<Prisoner>>();
    }
}
