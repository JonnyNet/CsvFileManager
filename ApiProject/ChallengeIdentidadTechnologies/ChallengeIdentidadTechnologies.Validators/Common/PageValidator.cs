using ChallengeIdentidadTechnologies.DTOs;
using FluentValidation;
using static ChallengeIdentidadTechnologies.Validators.Constans;

namespace ChallengeIdentidadTechnologies.Validators.Common
{
	internal class PageValidator : AbstractValidator<RequestFilter>
	{
		public PageValidator()
		{
			RuleFor(x => x.Page)
				.NotEqual(0)
				.WithMessage(NOT_DEFAULT_VALUE_ERROR_MESSAGE);
		}
	}
}
