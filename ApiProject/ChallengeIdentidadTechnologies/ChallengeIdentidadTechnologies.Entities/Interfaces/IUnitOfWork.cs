using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.Entities.Interfaces
{
	public interface IUnitOfWork
	{
		Task<int> SaveChanges();
	}
}
