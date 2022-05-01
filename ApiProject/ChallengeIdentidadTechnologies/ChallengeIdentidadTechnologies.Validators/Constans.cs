namespace ChallengeIdentidadTechnologies.Validators
{
	public class Constans
	{
		// Default values
		public const int MIN_LENGTH_NAME = 2;
		public const int MAX_LENGTH_NAME = 30;

		public const int MIN_VALUE_PAGE_SIXE = 1;
		public const int MAX_VALUE_PAGE_SIXE = 100;

		// Error Messages
		public const string NOT_NULL_ERROR_MESSAGE = "{PropertyName} cannot be null.";
		public const string NOT_EMPTY_ERROR_MESSAGE = "{PropertyName} cannot be empty.";
		public const string NOT_DEFAULT_VALUE_ERROR_MESSAGE = "The {PropertyName} field value is not valid";
		public const string LENGTH_ERROR_MESSAGE = "The {PropertyName} must have a length between {MinLength} and {MaxLength}.";
		public const string INCLUSICE_ERROR_MESSAGE = "The {PropertyName} must have a range from {From} to {To}.";

	}
}
