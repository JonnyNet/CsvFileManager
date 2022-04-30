using ChallengeIdentidadTechnologies.Entities.POCOs;
using Microsoft.EntityFrameworkCore;

namespace ChallengeIdentidadTechnologies.Repository.DataContext
{
	public class IdentidadTechnologiesContext :  DbContext
	{
		public IdentidadTechnologiesContext(DbContextOptions<IdentidadTechnologiesContext> options) : base(options)
		{

		}

		public DbSet<CsvFile> CsvFiles { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			var entityTypeBuilder = builder.Entity<CsvFile>();
			entityTypeBuilder.HasKey(x => x.Id);

			entityTypeBuilder.Property(x => x.Name)
				.HasMaxLength(100)
				.IsRequired();

			entityTypeBuilder.Property(x => x.Table)
				.HasMaxLength(50)
				.IsRequired();

			entityTypeBuilder.Property(x => x.CreatedAt)
				.HasColumnType("datetime")
				.HasDefaultValueSql("getdate()");
		}
	}
}
