using ChallengeIdentidadTechnologies.Validators;
using FluentValidation;
using IChallengeIdentidadTechnologiesValidator.Valations.Extensions;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.Valations.Adapters
{
	public class ValidatorAdapter<T> : IIdentidadTechnologiesValidator<T>
	{
		private readonly IValidator<T> _validator;

		public ValidatorAdapter(IValidator<T> validator)
		{
			_validator = validator;
		}

		public async Task Validate(T dto)
		{
			var resultValidation = await _validator.ValidateAsync(dto);
			resultValidation.NotifyHasError();
		}
	}
}
