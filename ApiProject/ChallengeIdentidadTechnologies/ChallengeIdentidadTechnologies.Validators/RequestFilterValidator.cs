using ChallengeIdentidadTechnologies.DTOs;
using ChallengeIdentidadTechnologies.Validators.Common;
using FluentValidation;

namespace ChallengeIdentidadTechnologies.Validators
{
	public class RequestFilterValidator : AbstractValidator<RequestFilter>
	{
		public RequestFilterValidator()
		{
			Include(new PageSizeValidator());
			Include(new PageValidator());
		}
	}
}
