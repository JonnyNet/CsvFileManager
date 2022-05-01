using ChallengeIdentidadTechnologies.Entities.Interfaces;
using ChallengeIdentidadTechnologies.Repository.DataContext;
using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.Repository.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IdentidadTechnologiesContext _context;

		public UnitOfWork(IdentidadTechnologiesContext context)
		{
			_context = context;
		}

		public Task<int> SaveChanges() =>
			_context.SaveChangesAsync();
	}
}
