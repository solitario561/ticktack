using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions dbContextOptions)
			: base(dbContextOptions)
		{
			
		}
		public DbSet<Tarea> Tarea { get; set; }
		public DbSet<Usuarios> Usuarios { get; set; }

	}
}
