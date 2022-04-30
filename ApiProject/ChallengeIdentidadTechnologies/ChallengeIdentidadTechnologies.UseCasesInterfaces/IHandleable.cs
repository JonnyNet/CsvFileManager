using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.UseCasesInterfaces
{
	public interface IHandleable<T>
	{
		Task Handle(T obj);
	}
}
