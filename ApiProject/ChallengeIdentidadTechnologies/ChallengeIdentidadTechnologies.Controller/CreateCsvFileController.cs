using ChallengeIdentidadTechnologies.DTOs;
using ChallengeIdentidadTechnologies.Presenters;
using ChallengeIdentidadTechnologies.UseCasesInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.Controller
{
	[Route("api/v1/csv-file")]
	[ApiController]
	public class CreateCsvFileController
	{
		private readonly ICreateCsvFileInput _createCsvFileInput;
		private readonly ICreateCsvFileOutput _createCsvFileOutput;

		public CreateCsvFileController(ICreateCsvFileInput createCsvFileInput, ICreateCsvFileOutput createCsvFileOutput)
		{
			_createCsvFileInput = createCsvFileInput;
			_createCsvFileOutput = createCsvFileOutput;
		}

		[HttpPost]
		public async Task<int> CreateCsvFile(CreateCsvFileDTO region)
		{
			await _createCsvFileInput.Handle(region);
			return ((IPresenter<int>)_createCsvFileOutput).Content;
		}
	}
}
