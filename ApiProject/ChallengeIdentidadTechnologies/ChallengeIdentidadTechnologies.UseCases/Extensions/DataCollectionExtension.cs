using ChallengeIdentidadTechnologies.Common.Collection;
using ChallengeIdentidadTechnologies.DTOs;
using ChallengeIdentidadTechnologies.Entities.POCOs;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;

namespace ChallengeIdentidadTechnologies.UseCases.Extensions
{
	public static class DataCollectionExtension
	{
		public static DataCollection<CsvFileDTO> ChangeType(this DataCollection<CsvFile> dataCollection) => new()
		{
			Page = dataCollection.Page,
			PageSize = dataCollection.PageSize,
			Total = dataCollection.Total,
			TotalPages = dataCollection.TotalPages,
			Data = dataCollection.Data.Select(x => new CsvFileDTO
			{
				Id = x.Id,
				Name = x.Name,
				CreatedAt = x.CreatedAt,
			})
		};

		public static DataCollection<dynamic> ToListobjet(this DataCollection<DataRow> dataCollection)
		{
			var row = dataCollection.Data.FirstOrDefault();
			var columns = row.Table.Columns.Cast<DataColumn>();
			return new()
			{
				Page = dataCollection.Page,
				PageSize = dataCollection.PageSize,
				Total = dataCollection.Total,
				TotalPages = dataCollection.TotalPages,
				Data = dataCollection.Data.Select(x => 
				{
					IDictionary<string, object> dn = new ExpandoObject();
					foreach (var column in columns)
					{
						dn[column.ColumnName] = x[column];
					}
					return dn;
				}),
			};
		}
	}
}
