using ChallengeIdentidadTechnologies.DTOs;
using ChallengeIdentidadTechnologies.Validators.Common;
using FluentValidation;

namespace ChallengeIdentidadTechnologies.Validators
{
	public class CsvFileFilterValidator : AbstractValidator<CsvFileFilter>
	{
		public CsvFileFilterValidator()
		{
			Include(new IdValidator());
			Include(new PageSizeValidator());
			Include(new PageValidator());
		}
	}
}
