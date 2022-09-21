using FluentValidation;
using Gevangenis.Contracts.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Gevangenis.Application;

public static class ApplicationRegistrations
{
    public static void RegisterApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetAssembly(typeof(ApplicationRegistrations)));
        //services.AddTransient<IValidator<AddCompanyCommand>, AddCompanyCommandValidator>();
        //services.AddValidatorsFromAssemblyContaining<AddCompanyCommandValidator>(ServiceLifetime.Transient);

        AssemblyScanner.FindValidatorsInAssemblyContaining<CommandBase<IValidator>>()
            .ForEach(x =>
            {
                services.Add(ServiceDescriptor.Transient(x.InterfaceType, x.ValidatorType));
                services.Add(ServiceDescriptor.Transient(x.ValidatorType, x.ValidatorType));
            });
    }
}