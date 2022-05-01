using ChallengeIdentidadTechnologies.Common.Collection;
using ChallengeIdentidadTechnologies.Entities.Interfaces;
using ChallengeIdentidadTechnologies.Repository.DataContext;
using ChallengeIdentidadTechnologies.Repository.Extensions;
using ChallengeIdentidadTechnologies.Repository.Helpers;
using ChallengeIdentidadTechnologies.Repository.Resources;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.Repository.Repositories
{
	public class CsvFileObjectRepository : ICsvFileObjectRepository
	{
		private readonly IdentidadTechnologiesContext _context;

		public CsvFileObjectRepository(IdentidadTechnologiesContext context)
		{
			_context = context;
		}

		public async Task<string> CreateTable(string nameFile, IEnumerable<string> columns)
		{
			var query = QueryHelper.GetCreateTableQuery(nameFile, columns);
			using (var cmd = _context.Database.GetDbConnection().CreateCommand())
			{
				cmd.CommandText = query.Item2;
				_context.Database.OpenConnection();
				await cmd.ExecuteNonQueryAsync();
			}
			return query.Item1;
		}

		public async Task<DataCollection<DataRow>> GetDataByTableName(string tableName, int page, int size)
		{
			var sqlStatement = string.Format(SqlStatement.CsvFile_SelectPagination, tableName);
			var dataTable = new DataTable();
			using (var cmd = _context.Database.GetDbConnection().CreateCommand())
			{
				cmd.CommandText = sqlStatement;
				_context.Database.OpenConnection();

				var reader = await cmd.ExecuteReaderAsync();
				dataTable.Load(reader);
				return dataTable.AsEnumerable().GetPaged(page, size);
			}
		}

		public async Task InsertData(string tableName, DataTable data)
		{
			var connection = _context.Database.GetDbConnection();
			using (var bulkCopy = new SqlBulkCopy((SqlConnection)connection))
			{
				_context.Database.OpenConnection();
				bulkCopy.DestinationTableName = tableName;
				await bulkCopy.WriteToServerAsync(data);
			}
		}
	}
}