using Farm.DataLayer;
using System.Data.Entity;

public class FarmDbContext : DbContext
{
	public FarmDbContext() : base("name=FarmDBEntities1")
	{
	}

	public DbSet<Animal> Animals { get; set; }
}