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
        //https://entityframeworkcore.com/knowledge-base/54787102/ef-foreign-key-reference-using-id-vs-object
        //https://entityframeworkcore.com/knowledge-base/54787102/ef-foreign-key-reference-using-id-vs-object
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

            modelBuilder.Entity<Note>()
                .HasIndex(n => n.DayID)
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

       //     modelBuilder.Entity<Day>()
       //         .HasOne(n => n.Note)
			    //.WithOne(d => d.Day);


			//.HasOne(n => n.Note)
			//.WithOne(d => d.DayID)
			//.OnDelete(DeleteBehavior.ClientCascade);

			//Hvordan laver jeg et 1-1 forhold mellem noter og dage uden at lave det der uendeligheds-løkke???
			//modelBuilder.Entity<Day>()
			//    .HasOne(N => N.Note)
			//    .WithOne(d => d.DayID)

			//modelBuilder.Entity<Note>()
			//	.HasOne


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
