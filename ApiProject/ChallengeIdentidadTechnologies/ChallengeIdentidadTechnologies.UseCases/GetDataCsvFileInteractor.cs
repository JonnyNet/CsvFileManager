using ChallengeIdentidadTechnologies.DTOs;
using ChallengeIdentidadTechnologies.Entities.Interfaces;
using ChallengeIdentidadTechnologies.UseCasesInterfaces;
using System;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.UseCases
{
	public class GetDataCsvFileInteractor : IGetDataCsvFileInput
	{
		private readonly ICsvFileRepository _csvFileRepository;
		private readonly IGetDataCsvFileOutput _getDataCsvFileOutput;

		public GetDataCsvFileInteractor(
			ICsvFileRepository csvFileRepository,
			IGetDataCsvFileOutput getDataCsvFileOutput)
		{
			_csvFileRepository = csvFileRepository;
			_getDataCsvFileOutput = getDataCsvFileOutput;
		}
		public Task Handle(RequestFilter obj)
		{
			throw new NotImplementedException();
		}
	}
}
