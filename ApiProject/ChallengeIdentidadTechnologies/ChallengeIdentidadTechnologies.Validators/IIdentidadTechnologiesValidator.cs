using System.Threading.Tasks;

namespace ChallengeIdentidadTechnologies.Validators
{
	public interface IIdentidadTechnologiesValidator<T>
	{
		Task Validate(T dto);
	}
}
