using ChallengeIdentidadTechnologies.DTOs;
using ChallengeIdentidadTechnologies.Entities.Interfaces;
using ChallengeIdentidadTechnologies.UseCases.Extensions;
using ChallengeIdentidadTechnologies.UseCasesInterfaces;
using ChallengeIdentidadTechnologies.Validators;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.UseCases
{
	public class GetDataCsvFileInteractor : IGetDataCsvFileInput
	{
		private readonly ICsvFileRepository _csvFileRepository;
		private readonly IGetDataCsvFileOutput _getDataCsvFileOutput;
		private readonly ICsvFileObjectRepository _csvFileObjectRepository;
		private readonly IIdentidadTechnologiesValidator<CsvFileFilter> _validator;

		public GetDataCsvFileInteractor(
			ICsvFileRepository csvFileRepository,
			IGetDataCsvFileOutput getDataCsvFileOutput,
			ICsvFileObjectRepository csvFileObjectRepository,
			IIdentidadTechnologiesValidator<CsvFileFilter> identidadTechnologiesValidator)
		{
			_csvFileRepository = csvFileRepository;
			_getDataCsvFileOutput = getDataCsvFileOutput;
			_csvFileObjectRepository = csvFileObjectRepository;
			_validator = identidadTechnologiesValidator;
		}
		public async Task Handle(CsvFileFilter filter)
		{
			await _validator.Validate(filter);

			var tableFile = await _csvFileRepository.GetTable(filter.Id);
			var collection = await _csvFileObjectRepository.GetDataByTableName(tableFile, filter.Page, filter.PageSize);
			var objectList = collection.ToListobjet();
			await _getDataCsvFileOutput.Handle(objectList);
		}
	}
}
