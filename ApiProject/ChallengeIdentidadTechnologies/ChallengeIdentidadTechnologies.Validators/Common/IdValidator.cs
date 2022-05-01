using ChallengeIdentidadTechnologies.DTOs;
using FluentValidation;
using static ChallengeIdentidadTechnologies.Validators.Constans;

namespace ChallengeIdentidadTechnologies.Validators.Common
{
	internal class IdValidator : AbstractValidator<CsvFileFilter>
	{
		public IdValidator()
		{
			RuleFor(x => x.Id)
				.NotEqual(0)
				.WithMessage(NOT_DEFAULT_VALUE_ERROR_MESSAGE);
		}
	}
}
