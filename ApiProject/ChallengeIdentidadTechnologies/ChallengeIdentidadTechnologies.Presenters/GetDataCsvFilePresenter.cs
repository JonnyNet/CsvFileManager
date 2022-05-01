using ChallengeIdentidadTechnologies.Common.Collection;
using ChallengeIdentidadTechnologies.UseCasesInterfaces;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.Presenters
{
	public class GetDataCsvFilePresenter : IGetDataCsvFileOutput, IPresenter<DataCollection<object>>
	{
		public DataCollection<object> Content { get; private set; }

		public Task Handle(DataCollection<object> dataCollection)
		{
			Content = dataCollection;
			return Task.CompletedTask;
		}
	}
}
