using ChallengeIdentidadTechnologies.Presenters;
using ChallengeIdentidadTechnologies.Repository;
using ChallengeIdentidadTechnologies.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeIdentidadTechnologies.IoC
{
	public static class DependencyContainer
	{
		public static IServiceCollection AddChallengeIdentidadTechnologiesDependencies(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddRepositories(configuration);
			services.AddUsesCasesServices();
			services.AddPresenters();
			return services;
		}

		public static IApplicationBuilder RunMigrations(this IApplicationBuilder app)
		{
			app.RunMigrationsRepositories();
			return app;
		}
	}
}
