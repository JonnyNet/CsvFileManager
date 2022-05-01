using ChallengeIdentidadTechnologies.DTOs;
using FluentValidation;
using static ChallengeIdentidadTechnologies.Validators.Constans;

namespace ChallengeIdentidadTechnologies.Validators.Common
{
	internal class PageSizeValidator : AbstractValidator<RequestFilter>
	{
		public PageSizeValidator()
		{
			RuleFor(x => x.PageSize)
				.InclusiveBetween(MIN_VALUE_PAGE_SIXE, MAX_VALUE_PAGE_SIXE)
				.WithMessage(INCLUSICE_ERROR_MESSAGE);
		}
	}
}
