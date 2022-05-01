using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ChallengeIdentidadTechnologies.Repository.DataContext
{
	public class IdentidadTechnologiesContextFactory : IDesignTimeDbContextFactory<IdentidadTechnologiesContext>
	{
		public IdentidadTechnologiesContext CreateDbContext(string[] args)
		{
			var optionBuilder = new DbContextOptionsBuilder<IdentidadTechnologiesContext>();
			optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=IdentidadTechnologies");
			return new IdentidadTechnologiesContext(optionBuilder.Options);
		}
	}
}
