using ChallengeIdentidadTechnologies.CsvManager;
using ChallengeIdentidadTechnologies.CsvManager.Adapters;
using ChallengeIdentidadTechnologies.UseCasesInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeIdentidadTechnologies.UseCases
{
	public static class DependencyContainer
	{
		public static IServiceCollection AddUsesCasesServices(this IServiceCollection services)
		{
			services.AddTransient<ICreateCsvFileInput, CreateCsvFileInteractor>();
			services.AddTransient<IGetAllCsvFileInput, GetAllCsvFileInteractor>();
			services.AddTransient<IGetDataCsvFileInput, GetDataCsvFileInteractor>();

			services.AddTransient<ICsvAdapter, CsvAdapter>();
			return services;
		}
	}
}
