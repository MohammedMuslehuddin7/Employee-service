using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VoterInfoRepoPattern.Models
{
    public partial class ToDoTaskContext : DbContext
    {
        public ToDoTaskContext()
        {
        }

        public ToDoTaskContext(DbContextOptions<ToDoTaskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoginForTheatre> LoginForTheatre { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }
        public virtual DbSet<Theatre> Theatre { get; set; }
        public virtual DbSet<VoterInfo> VoterInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-3U73IJF\\MUSLEHSQLEXPRESS;Database=ToDoTask;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginForTheatre>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Theatre>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.Property(e => e.MovieId).HasColumnName("movieID");

                entity.Property(e => e.AvailableTickets).HasColumnName("availableTickets");

                entity.Property(e => e.MovieDate)
                    .HasColumnName("movieDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MovieName)
                    .HasColumnName("movieName")
                    .HasMaxLength(50);

                entity.Property(e => e.MoviePrice).HasColumnName("moviePrice");

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalAmount")
                    .HasColumnType("decimal(8, 2)");
            });

            modelBuilder.Entity<VoterInfo>(entity =>
            {
                entity.HasKey(e => e.VoterId);

                entity.Property(e => e.VoterId).HasColumnName("VoterID");

                entity.Property(e => e.VoterCounty)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VoterFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VoterState)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
