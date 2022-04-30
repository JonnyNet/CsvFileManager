using ChallengeIdentidadTechnologies.Entities.Interfaces;
using ChallengeIdentidadTechnologies.Entities.POCOs;
using ChallengeIdentidadTechnologies.Repository.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

		public async Task<int> Create(CsvFile csvFile)
		{
			await _context.AddAsync(csvFile);
			return csvFile.Id;
		}

		public Task<string> GetTable(int id)
			=> _context.CsvFiles
			.Where(x => x.Id == id)
			.Select(x => x.Table)
			.SingleOrDefaultAsync();

		public async Task<IEnumerable<CsvFile>> GetAll()
		{
			var allObjects = await _context.CsvFiles.Select(s => new CsvFile
			{
				Id = s.Id,
				Name = s.Name,
				CreatedAt = s.CreatedAt,
			}).ToListAsync();
			return allObjects;
		}
	}
}
