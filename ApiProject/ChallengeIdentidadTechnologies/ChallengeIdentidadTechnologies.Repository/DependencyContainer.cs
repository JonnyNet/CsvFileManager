using ChallengeIdentidadTechnologies.Entities.Interfaces;
using ChallengeIdentidadTechnologies.Repository.DataContext;
using ChallengeIdentidadTechnologies.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ChallengeIdentidadTechnologies.Repository
{
	public static class DependencyContainer
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<IdentidadTechnologiesContext>(options
				=> options.UseSqlServer(configuration.GetConnectionString("IdentidadTechnologies")));
			services.AddScoped<ICsvFileRepository, CsvFileRespository>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<ICsvFileObjectRepository, CsvFileObjectRepository>();
			return services;
		}

		public static IApplicationBuilder RunMigrationsRepositories(this IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<IdentidadTechnologiesContext>();
				context.Database.Migrate();
			}
			return app;
		}
	}
}
