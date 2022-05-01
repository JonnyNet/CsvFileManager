using ChallengeIdentidadTechnologies.UseCasesInterfaces;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.Presenters
{
	public class CreateCsvFilePresenter : ICreateCsvFileOutput, IPresenter<int>
	{
		public int Content { get; private set; }

		public Task Handle(int id)
		{
			Content = id;
			return Task.CompletedTask;
		}
	}
}
