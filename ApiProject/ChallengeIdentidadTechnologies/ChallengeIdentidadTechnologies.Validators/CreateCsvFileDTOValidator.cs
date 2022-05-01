using ChallengeIdentidadTechnologies.DTOs;
using FluentValidation;
using static ChallengeIdentidadTechnologies.Validators.Constans;

namespace ChallengeIdentidadTechnologies.Validators
{
	public class CreateCsvFileDTOValidator : AbstractValidator<CreateCsvFileDTO>
	{
		public CreateCsvFileDTOValidator()
		{
			RuleFor(x => x.Name)
				.Cascade(CascadeMode.Stop)
				.NotNull()
				.WithMessage(NOT_NULL_ERROR_MESSAGE)
				.NotEmpty()
				.WithMessage(NOT_EMPTY_ERROR_MESSAGE)
				.Length(MIN_LENGTH_NAME, MAX_LENGTH_NAME)
				.WithMessage(LENGTH_ERROR_MESSAGE);

			RuleFor(x => x.Data)
				.Cascade(CascadeMode.Stop)
				.NotNull()
				.WithMessage(NOT_NULL_ERROR_MESSAGE)
				.NotEmpty()
				.WithMessage(NOT_EMPTY_ERROR_MESSAGE)
				.Length(MIN_LENGTH_NAME, MAX_LENGTH_NAME)
				.WithMessage(LENGTH_ERROR_MESSAGE)
				.Matches("^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)?$")
				.WithMessage(NOT_DEFAULT_VALUE_ERROR_MESSAGE);
		}
	}
}
