using ChallengeIdentidadTechnologies.DTOs;
using ChallengeIdentidadTechnologies.Entities.Interfaces;
using ChallengeIdentidadTechnologies.UseCasesInterfaces;
using System;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.UseCases
{
	public class GetAllCsvFileInteractor : IGetAllCsvFileInput
	{
		private readonly ICsvFileRepository _csvFileRepository;
		private readonly IGetAllCsvFileOutput _getAllCsvFileOutput;

		public GetAllCsvFileInteractor(
			ICsvFileRepository csvFileRepository,
			IGetAllCsvFileOutput getAllCsvFileOutput)
		{
			_csvFileRepository = csvFileRepository;
			_getAllCsvFileOutput = getAllCsvFileOutput;
		}

		public Task Handle(RequestFilter obj)
		{
			throw new NotImplementedException();
		}
	}
}
