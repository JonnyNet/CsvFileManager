using ChallengeIdentidadTechnologies.Common.Collection;
using ChallengeIdentidadTechnologies.DTOs;
using ChallengeIdentidadTechnologies.UseCasesInterfaces;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.Presenters
{
	public class GetAllCsvFilePresenter : IGetAllCsvFileOutput, IPresenter<DataCollection<CsvFileDTO>>
	{
		public DataCollection<CsvFileDTO> Content { get; private set; }

		public Task Handle(DataCollection<CsvFileDTO> dataCollection)
		{
			Content = dataCollection;
			return Task.CompletedTask;
		}
	}
}
