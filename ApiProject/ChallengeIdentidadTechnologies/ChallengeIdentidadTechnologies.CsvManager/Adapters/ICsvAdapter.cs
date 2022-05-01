using System.Data;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.CsvManager.Adapters
{
	public interface ICsvAdapter
	{
		Task<DataTable> GetDataFile(string stringData);
	}
}
