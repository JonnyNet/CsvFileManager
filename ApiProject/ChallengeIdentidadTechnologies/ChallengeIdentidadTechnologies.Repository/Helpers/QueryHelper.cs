using ChallengeIdentidadTechnologies.Repository.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ChallengeIdentidadTechnologies.Repository.Helpers
{
	public class QueryHelper
	{
		public static (string, string) GetCreateTableQuery(string nameFile, IEnumerable<string> columns)
		{
			nameFile = Path.GetFileNameWithoutExtension(nameFile);
			nameFile += Guid.NewGuid();
			var tableName = Regex.Replace(nameFile, "[^a-zA-Z0-9]", "").ToLower();
			var columnsAndType = string.Join(",\n", columns.Select(x => $"{x} VARCHAR(MAX)"));
			var query = string.Format(SqlStatement.CsvFile_CreateTable, tableName, columnsAndType);
			return (tableName, query);
		}
	}
}
