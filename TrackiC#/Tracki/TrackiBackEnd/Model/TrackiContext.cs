using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TrackiBackEnd.Model
{
    public partial class TrackiContext : DbContext
    {
        public TrackiContext()
        {
        }

        public TrackiContext(DbContextOptions<TrackiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Release> Releases { get; set; }
        public virtual DbSet<ReleaseType> ReleaseTypes { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=123456a+;Database=Tracki");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Czech_Czechia.1250");

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("accountTypes_pkey");

                entity.ToTable("accountTypes");

                entity.Property(e => e.TypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("typeID");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("typeName");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.ToTable("artists");

                entity.HasIndex(e => e.UserId, "fki_FK_userID");

                entity.Property(e => e.ArtistId)
                    .ValueGeneratedNever()
                    .HasColumnName("artistID");

                entity.Property(e => e.ArtistLocation).HasColumnName("artistLocation");

                entity.Property(e => e.ArtistName).HasColumnName("artistName");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Artists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_userID");
            });

            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable("photos");

                entity.Property(e => e.PhotoId)
                    .ValueGeneratedNever()
                    .HasColumnName("photoID");

                entity.Property(e => e.Location).HasColumnName("location");
            });

            modelBuilder.Entity<Release>(entity =>
            {
                entity.ToTable("releases");

                entity.HasIndex(e => e.ArtistId, "fki_FK_artistID");

                entity.HasIndex(e => e.ReleaseTypeId, "fki_FK_releaseTypeID");

                entity.HasIndex(e => e.PhotoId, "fki_Fk_PhotoIDRelease");

                entity.Property(e => e.ReleaseId)
                    .ValueGeneratedNever()
                    .HasColumnName("releaseID");

                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .HasColumnName("albumName");

                entity.Property(e => e.ArtistId).HasColumnName("artistID");

                entity.Property(e => e.PhotoId).HasColumnName("photoID");

                entity.Property(e => e.ReleaseTypeId).HasColumnName("releaseTypeID");

                entity.Property(e => e.YearOfRelease).HasColumnName("yearOfRelease");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Releases)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_artistID");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.Releases)
                    .HasForeignKey(d => d.PhotoId)
                    .HasConstraintName("Fk_PhotoIDRelease");

                entity.HasOne(d => d.ReleaseType)
                    .WithMany(p => p.Releases)
                    .HasForeignKey(d => d.ReleaseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_releaseTypeID");
            });

            modelBuilder.Entity<ReleaseType>(entity =>
            {
                entity.ToTable("releaseTypes");

                entity.Property(e => e.ReleaseTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("releaseTypeID");

                entity.Property(e => e.ReleaseTypeName)
                    .IsRequired()
                    .HasColumnName("releaseTypeName");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.ToTable("songs");

                entity.HasIndex(e => e.ReleaseId, "fki_FK_albumID");

                entity.Property(e => e.SongId)
                    .ValueGeneratedNever()
                    .HasColumnName("songID");

                entity.Property(e => e.ReleaseId).HasColumnName("releaseID");

                entity.Property(e => e.SongLocation)
                    .IsRequired()
                    .HasColumnName("songLocation");

                entity.Property(e => e.SongName)
                    .IsRequired()
                    .HasColumnName("songName");

                entity.HasOne(d => d.Release)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.ReleaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_releaseID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.PhotoId, "fki_FK_PhotoIDUser");

                entity.HasIndex(e => e.AccountTypeId, "fki_FK_accountTypeID");

                entity.Property(e => e.UserId)
                    .HasColumnName("userID")
                    .HasIdentityOptions(null, null, 0L, null, null, null);

                entity.Property(e => e.AccountTypeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("accountTypeID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.PasswordHash).HasColumnName("passwordHash");

                entity.Property(e => e.PhotoId).HasColumnName("photoID");

                entity.Property(e => e.UserName).HasColumnName("userName");

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_accountTypeID");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PhotoId)
                    .HasConstraintName("FK_PhotoIDUser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
