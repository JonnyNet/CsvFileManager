using ChallengeIdentidadTechnologies.Common.Collection;
using ChallengeIdentidadTechnologies.DTOs;
using ChallengeIdentidadTechnologies.Presenters;
using ChallengeIdentidadTechnologies.UseCasesInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.Controller
{
	[Route("api/v1/csv-file")]
	[ApiController]
	public class GetAllCsvFileController
	{
		private readonly IGetAllCsvFileInput _getAllCsvFileInput;
		private readonly IGetAllCsvFileOutput _getAllCsvFileOutput;

		public GetAllCsvFileController(IGetAllCsvFileInput getAllCsvFileInput, IGetAllCsvFileOutput getAllCsvFileOutput)
		{
			_getAllCsvFileInput = getAllCsvFileInput;
			_getAllCsvFileOutput = getAllCsvFileOutput;
		}

		[HttpGet]
		public async Task<DataCollection<CsvFileDTO>> GetAllCsvFile(
			[FromQuery] int page = 1,
			[FromQuery] int pageSize = 10)
		{

			await _getAllCsvFileInput.Handle(new RequestFilter
			{
				PageSize = pageSize,
				Page = page,
			});
			return ((IPresenter<DataCollection<CsvFileDTO>>)_getAllCsvFileOutput).Content;
		}
	}
}
