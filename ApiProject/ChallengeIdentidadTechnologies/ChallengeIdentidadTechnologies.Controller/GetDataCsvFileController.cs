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
	public class GetDataCsvFileController
	{
		private readonly IGetDataCsvFileInput _getDataCsvFileInput;
		private readonly IGetDataCsvFileOutput _getDataCsvFileOutput;

		public GetDataCsvFileController(IGetDataCsvFileInput getDataCsvFileInput, IGetDataCsvFileOutput getDataCsvFileOutput)
		{
			_getDataCsvFileInput = getDataCsvFileInput;
			_getDataCsvFileOutput = getDataCsvFileOutput;
		}

		[HttpGet]
		[Route("{id}/items")]
		public async Task<DataCollection<object>> GetPropertie(
			[FromRoute] int id,
			[FromQuery] int page = 1,
			[FromQuery] int pageSize = 10)
		{

			await _getDataCsvFileInput.Handle(new CsvFileFilter
			{
				Id = id,
				PageSize = pageSize,
				Page = page,
			});
			return ((IPresenter<DataCollection<object>>)_getDataCsvFileOutput).Content;
		}
	}
}
