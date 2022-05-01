using ChallengeIdentidadTechnologies.UseCasesInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeIdentidadTechnologies.Presenters
{
	public static class DependencyContainer
	{
		public static IServiceCollection AddPresenters(this IServiceCollection services)
		{
			services.AddScoped<ICreateCsvFileOutput, CreateCsvFilePresenter>();
			services.AddScoped<IGetAllCsvFileOutput, GetAllCsvFilePresenter>();
			services.AddScoped<IGetDataCsvFileOutput, GetDataCsvFilePresenter>();
			return services;
		}
	}
}
