using ChallengeIdentidadTechnologies.Common.Collection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.Repository.Extensions
{
	public static class QueryableExtension
	{
		public static async Task<DataCollection<T>> GetPagedAsync<T>(this IQueryable<T> query, int page, int take)
		{
			var originalPage = page;
			page--;
			if (page > 0)
			{
				page *= take;
			}

			var result = new DataCollection<T>
			{
				Data = await query.Skip(page).Take(take).ToListAsync(),
				Total = await query.CountAsync(),
				Page = originalPage,
				PageSize = take,
			};

			if(result.Total > 0)
			{
				result.TotalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));
			}

			return result;
		}
	}
}
