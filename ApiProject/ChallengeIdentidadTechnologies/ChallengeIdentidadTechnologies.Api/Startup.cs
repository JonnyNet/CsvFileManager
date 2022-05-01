using ChallengeIdentidadTechnologies.Api.Filters;
using ChallengeIdentidadTechnologies.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ChallengeIdentidadTechnologies.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChallengeIdentidadTechnologies.Api", Version = "v1" });
			});
			services.AddChallengeIdentidadTechnologiesDependencies(Configuration);
			services.AddControllers(option => option.Filters.Add<ExceptionHandlingAttribute>());

			services.AddCors(options =>
			{
				options.AddDefaultPolicy(
				builder =>
				{
					builder.WithOrigins("http://localhost:4200")
					.AllowAnyHeader()
					.WithMethods(new string[] { "POST", "GET" })
					.AllowCredentials();
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.RunMigrations();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChallengeIdentidadTechnologies.Api v1"));
			}

			app.UseCors(options =>
				options.WithOrigins("http://localhost:4200")
				.WithMethods(new string[] { "POST", "GET" })
				.AllowAnyHeader()
				.AllowCredentials());

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
