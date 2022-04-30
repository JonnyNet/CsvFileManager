using ChallengeIdentidadTechnologies.Entities.POCOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.Entities.Interfaces
{
	public interface ICsvFileRepository
	{
		Task<int> Create(CsvFile csvFile);
		Task<IEnumerable<CsvFile>> GetAll();
		Task<string> GetTable(int id);
	}
}
