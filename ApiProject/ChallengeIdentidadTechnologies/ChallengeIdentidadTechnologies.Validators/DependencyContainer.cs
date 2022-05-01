using ChallengeIdentidadTechnologies.DTOs;
using ChallengeIdentidadTechnologies.Valations.Adapters;
using ChallengeIdentidadTechnologies.Validators.Common;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeIdentidadTechnologies.Validators
{
	public static class DependencyContainer
	{
		public static IServiceCollection AddValidators(this IServiceCollection services)
		{
			services.AddScoped<IValidator<CreateCsvFileDTO>, CreateCsvFileDTOValidator>();
			services.AddScoped<IValidator<RequestFilter>, RequestFilterValidator>();
			services.AddScoped<IValidator<CsvFileFilter>, CsvFileFilterValidator>();
			services.AddScoped<IValidator<int>, IntegerValidator>();

			services.AddScoped(typeof(IIdentidadTechnologiesValidator<>), typeof(ValidatorAdapter<>));
			return services;
		}
	}
}
