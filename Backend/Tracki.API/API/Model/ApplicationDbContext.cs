using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TrackiBackEnd.Model
{
	public partial class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext()
		{
		}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AccountType>().HasData(new AccountType[]
			{
				new AccountType{ TypeId=1, TypeName="user" },
				new AccountType{ TypeId=2, TypeName="premiumUser" },
				new AccountType{ TypeId=3, TypeName="admin" },
			});
		}

		public virtual DbSet<AccountType> AccountTypes { get; set; }
		public virtual DbSet<Artist> Artists { get; set; }
		public virtual DbSet<Photo> Photos { get; set; }
		public virtual DbSet<Release> Releases { get; set; }
		public virtual DbSet<ReleaseType> ReleaseTypes { get; set; }
		public virtual DbSet<Song> Songs { get; set; }
		public virtual DbSet<User> Users { get; set; }

	}
}
