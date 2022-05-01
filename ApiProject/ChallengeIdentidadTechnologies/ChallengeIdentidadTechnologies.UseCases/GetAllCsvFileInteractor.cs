using ChallengeIdentidadTechnologies.DTOs;
using ChallengeIdentidadTechnologies.Entities.Interfaces;
using ChallengeIdentidadTechnologies.UseCases.Extensions;
using ChallengeIdentidadTechnologies.UseCasesInterfaces;
using ChallengeIdentidadTechnologies.Validators;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.UseCases
{
	public class GetAllCsvFileInteractor : IGetAllCsvFileInput
	{
		private readonly ICsvFileRepository _csvFileRepository;
		private readonly IGetAllCsvFileOutput _getAllCsvFileOutput;
		private readonly IIdentidadTechnologiesValidator<RequestFilter> _validator;

		public GetAllCsvFileInteractor(
			ICsvFileRepository csvFileRepository,
			IGetAllCsvFileOutput getAllCsvFileOutput,
			IIdentidadTechnologiesValidator<RequestFilter> identidadTechnologiesValidator)
		{
			_csvFileRepository = csvFileRepository;
			_getAllCsvFileOutput = getAllCsvFileOutput;
			_validator = identidadTechnologiesValidator;
		}

		public async Task Handle(RequestFilter filter)
		{
			await _validator.Validate(filter);

			var collection = await _csvFileRepository.GetAll(filter.Page, filter.PageSize);
			var responseCollection = collection.ChangeType();
			await _getAllCsvFileOutput.Handle(responseCollection);
		}
	}
}
