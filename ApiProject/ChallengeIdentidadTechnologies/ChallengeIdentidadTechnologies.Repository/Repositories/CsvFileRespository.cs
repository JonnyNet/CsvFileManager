using ChallengeIdentidadTechnologies.Common.Collection;
using ChallengeIdentidadTechnologies.Entities.Interfaces;
using ChallengeIdentidadTechnologies.Entities.POCOs;
using ChallengeIdentidadTechnologies.Repository.DataContext;
using ChallengeIdentidadTechnologies.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.Repository.Repositories
{
	public class CsvFileRespository : ICsvFileRepository
	{
		private readonly IdentidadTechnologiesContext _context;

		public CsvFileRespository(IdentidadTechnologiesContext context)
		{
			_context = context;
		}

		public async Task Create(CsvFile csvFile)
		{
			await _context.AddAsync(csvFile);
		}

		public Task<string> GetTable(int id)
			=> _context.CsvFiles
			.Where(x => x.Id == id)
			.Select(x => x.Table)
			.SingleOrDefaultAsync();

		public Task<DataCollection<CsvFile>> GetAll(int page, int size)
		{
			var allObjects = _context.CsvFiles.Select(s => new CsvFile
			{
				Id = s.Id,
				Name = s.Name,
				CreatedAt = s.CreatedAt,
			}).GetPagedAsync(page, size);
			return allObjects;
		}
	}
}
