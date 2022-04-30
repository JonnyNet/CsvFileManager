using ChallengeIdentidadTechnologies.DTOs;
using ChallengeIdentidadTechnologies.Entities.Interfaces;
using ChallengeIdentidadTechnologies.UseCasesInterfaces;
using System;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.UseCases
{
	public class CreateCsvFileInteractor : ICreateCsvFileInput
	{
		private readonly ICsvFileRepository _csvFileRepository;
		private readonly ICreateCsvFileOutput _createCsvFileOutput;
		private readonly IUnitOfWork _unitOfWork;

		public CreateCsvFileInteractor(
			ICsvFileRepository csvFileRepository,
			ICreateCsvFileOutput createCsvFileOutput,
			IUnitOfWork unitOfWork)
		{
			_csvFileRepository = csvFileRepository;
			_createCsvFileOutput = createCsvFileOutput;
			_unitOfWork = unitOfWork;
		}

		public Task Handle(CreateCsvFileDTO obj)
		{
			throw new NotImplementedException();
		}
	}
}
