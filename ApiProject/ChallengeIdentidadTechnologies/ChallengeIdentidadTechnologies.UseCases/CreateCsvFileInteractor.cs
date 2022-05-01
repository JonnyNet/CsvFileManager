using ChallengeIdentidadTechnologies.CsvManager.Adapters;
using ChallengeIdentidadTechnologies.DTOs;
using ChallengeIdentidadTechnologies.Entities.Interfaces;
using ChallengeIdentidadTechnologies.Entities.POCOs;
using ChallengeIdentidadTechnologies.UseCasesInterfaces;
using ChallengeIdentidadTechnologies.Validators;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.UseCases
{
	public class CreateCsvFileInteractor : ICreateCsvFileInput
	{
		private readonly ICsvFileRepository _csvFileRepository;
		private readonly ICreateCsvFileOutput _createCsvFileOutput;
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICsvAdapter _csvAdapter;
		private readonly ICsvFileObjectRepository _csvFileObjectRepository;
		private readonly IIdentidadTechnologiesValidator<CreateCsvFileDTO> _validator;

		public CreateCsvFileInteractor(
			ICsvFileRepository csvFileRepository,
			ICreateCsvFileOutput createCsvFileOutput,
			IUnitOfWork unitOfWork,
			ICsvAdapter csvAdapter,
			ICsvFileObjectRepository csvFileObjectRepository,
			IIdentidadTechnologiesValidator<CreateCsvFileDTO> identidadTechnologiesValidator)
		{
			_csvFileRepository = csvFileRepository;
			_createCsvFileOutput = createCsvFileOutput;
			_unitOfWork = unitOfWork;
			_csvAdapter = csvAdapter;
			_csvFileObjectRepository = csvFileObjectRepository;
			_validator = identidadTechnologiesValidator;
		}

		public async Task Handle(CreateCsvFileDTO csvFileDto)
		{
			await _validator.Validate(csvFileDto);

			var dataTable = await _csvAdapter.GetDataFile(csvFileDto.Data);
			var columnNames = dataTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName);

			var tableName = await _csvFileObjectRepository.CreateTable(csvFileDto.Name, columnNames);
			await _csvFileObjectRepository.InsertData(tableName, dataTable);

			var file = new CsvFile 
			{ 
				Name = csvFileDto.Name,
				Table = tableName,
			};

			await _csvFileRepository.Create(file);
			await _unitOfWork.SaveChanges();
			await _createCsvFileOutput.Handle(file.Id);
		}
	}
}
