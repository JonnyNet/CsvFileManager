using ChallengeIdentidadTechnologies.Common.Collection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ChallengeIdentidadTechnologies.Repository.Extensions
{
	public static class EnumerableExtencion
	{
		public static DataCollection<DataRow> GetPaged(this IEnumerable<DataRow> query, int page, int take)
		{
			var originalPages = page;
			page--;

			if (page > 0)
			{
				page *= take;
			}

			var data = query.Skip(page).Take(take).ToList();

			var result = new DataCollection<DataRow>
			{
				Data = data,
				Total = query.Count(),
				Page = originalPages,
				PageSize = take,
			};

			if (result.Total > 0)
			{
				result.TotalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));
			}

			return result;
		}
	}
}
