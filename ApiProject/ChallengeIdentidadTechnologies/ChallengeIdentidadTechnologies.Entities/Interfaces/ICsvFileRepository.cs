using ChallengeIdentidadTechnologies.Common.Collection;
using ChallengeIdentidadTechnologies.Entities.POCOs;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.Entities.Interfaces
{
	public interface ICsvFileRepository
	{
		Task Create(CsvFile csvFile);
		Task<DataCollection<CsvFile>> GetAll(int page, int size);
		Task<string> GetTable(int id);
	}
}
