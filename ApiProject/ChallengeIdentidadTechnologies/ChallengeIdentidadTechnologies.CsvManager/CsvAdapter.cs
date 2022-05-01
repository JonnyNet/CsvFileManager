using ChallengeIdentidadTechnologies.CsvManager.Adapters;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.CsvManager
{
	public class CsvAdapter : ICsvAdapter
	{
		private static readonly CsvConfiguration _READER_CONFIG = new CsvConfiguration(CultureInfo.InvariantCulture)
		{
			ExceptionMessagesContainRawData = false
		};

		public async Task<DataTable> GetDataFile(string stringData)
		{
			var dataTable = new DataTable();
			var base64 = stringData.Split(',')[1];
			var bytes = Convert.FromBase64String(base64);
			using (var targetFile = new MemoryStream(bytes))
			{
				using (var fileReader = new StreamReader(targetFile))
				{
					using (var csvReader = new CsvReader(fileReader, _READER_CONFIG))
					{
						await csvReader.ReadAsync().ConfigureAwait(false);
						csvReader.ReadHeader();

						var headers = ReadHeaderNames(csvReader);
						foreach (var header in headers)
						{
							dataTable.Columns.Add(header.Value);
						}
						await ReadAllRecordsAsync(csvReader, headers, dataTable);
						return dataTable;
					}
				}
			}
		}

		private async Task ReadAllRecordsAsync(CsvReader csvReader, IDictionary<int, string> headerNames, DataTable dataTable)
		{
			while (await csvReader.ReadAsync().ConfigureAwait(false))
			{
				var rowData = FillOutRowValues(csvReader, headerNames, dataTable);
				dataTable.Rows.Add(rowData);
			}
		}

		private DataRow FillOutRowValues(CsvReader csvReader, IDictionary<int, string> headerNames, DataTable dataTable)
		{
			var rowData = dataTable.NewRow();
			foreach (KeyValuePair<int, string> header in headerNames)
			{
				rowData[header.Value] = csvReader.GetField(header.Key);
			}
			return rowData;
		}

		private IDictionary<int, string> ReadHeaderNames(CsvReader csvReader)
		{
			var originalHeaders = csvReader.HeaderRecord
				.Select((header, index) => new { index, header })
				.ToDictionary(k => k.index, v => Regex.Replace(v.header, "[^a-zA-Z0-9]", "").ToLower());

			var duplicatedColumns = originalHeaders
					.GroupBy(c => c.Value, v => v.Key)
					.Where(g => g.Count() > 1);

			if (duplicatedColumns.Any())
			{
				originalHeaders = originalHeaders
						.ToDictionary(k => k.Key, v => FormatHeaderName(v, duplicatedColumns));
			}

			return originalHeaders;
		}

		private string FormatHeaderName(KeyValuePair<int, string> headerPair, IEnumerable<IGrouping<string, int>> duplicatedColumns)
		{
			string columnName = headerPair.Value;

			var duplicatedGroupedColumn = duplicatedColumns
				.FirstOrDefault(dc => dc.Key.Equals(headerPair.Value));

			if (duplicatedGroupedColumn != default)
			{
				IEnumerable<(int FileIndex, int ColumnIndex)> indexesList = duplicatedGroupedColumn
					.Select((fileIndex, index) => (FileIndex: fileIndex, ColumnIndex: index + 1));

				(int FileIndex, int ColumnIndex) columnIndexes = indexesList
					.FirstOrDefault(i => i.FileIndex == headerPair.Key);

				columnName = $"{columnName}_D{columnIndexes.ColumnIndex}";
			}

			return columnName;
		}
	}
}
