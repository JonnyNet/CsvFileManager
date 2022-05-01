using FluentValidation;
using static ChallengeIdentidadTechnologies.Validators.Constans;

namespace ChallengeIdentidadTechnologies.Validators.Common
{
	internal class IntegerValidator : AbstractValidator<int>
	{
		public IntegerValidator()
		{
			RuleFor(x => x)
				.NotEqual(0)
				.WithMessage(NOT_DEFAULT_VALUE_ERROR_MESSAGE);
		}
	}
}
