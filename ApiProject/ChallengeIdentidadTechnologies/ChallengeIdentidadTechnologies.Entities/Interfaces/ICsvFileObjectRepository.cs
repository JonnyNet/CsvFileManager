using ChallengeIdentidadTechnologies.Common.Collection;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.Entities.Interfaces
{
	public interface ICsvFileObjectRepository
	{
		Task<string> CreateTable(string nameFile, IEnumerable<string> columns);
		Task InsertData(string tableName, DataTable data);
		Task<DataCollection<DataRow>> GetDataByTableName(string tableName, int page, int size);
	}
}
