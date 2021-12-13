using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBStest01.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MBS_API
{
    public class MBSContext : DbContext
    {
        //https://stackoverflow.com/questions/54596180/asp-net-core-web-api-ef-core-models-with-foreign-key-relationship
        public DbSet<Day> Days { get; set; }
        public DbSet<Influence> Influences { get; set; }
        public DbSet<Mood> Moods { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        public static readonly ILoggerFactory ConsoleLoggerFactory =
            LoggerFactory.Create(builder =>
            {
                builder
                        .AddFilter((category, level) =>
                            category == DbLoggerCategory.Database.Command.Name
                            && level == LogLevel.Information)
                        .AddConsole();
            });

        public MBSContext(DbContextOptions<MBSContext> options) : base(options)
        {

        }

        public MBSContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //string _connectionString = config.GetConnectionString("MBSDB");
            optionsBuilder.UseSqlServer(config.GetConnectionString("MBSDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Bliver nødt til at definere unique constraint her med "Fluent API", da det ikke understøttes gennem data annotations i selve modellen.
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserEmail)
                .IsUnique();

            //modelBuilder.Entity<Day>()
            //    .HasIndex(d => d.Note.NoteID)
            //    .IsUnique();
            //modelBuilder.Entity<Day>()
            //    .HasOne(n => n.Note)
            //    .WithOne(d => d.Day)
            //    .HasForeignKey<Note>(n => n.DayID);

            //modelBuilder.Entity<Note>()
            //    .HasOne(d => d.Day)
            //    .WithOne(n => n.Note)
            //    .HasForeignKey<Day>(n => n.Note.NoteID);

            modelBuilder.Entity<Day>()
                .HasOne(n => n.Note)
                .WithOne(d => d.Day)
                .OnDelete(DeleteBehavior.ClientCascade);

			//modelBuilder.Entity<Note>()
			//	.HasOne<Day>(d => d.Day)
   //             .WithOne<Note>(n => n.)


			base.OnModelCreating(modelBuilder);
        }
        //modelBuilder.Entity<Day>()
        //        .Property(d => d.MoodName)
        //        .HasConversion<int>();

        //    modelBuilder.Entity<Day>()
        //        .Property(d => d.InfluenceName)
        //        .HasConversion<int>();
    }
}
