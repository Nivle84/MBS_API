﻿// <auto-generated />
using System;
using MBS_API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MBSAPITest01.Migrations
{
    [DbContext(typeof(MBSContext))]
    partial class MBSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MBStest01.Models.Day", b =>
                {
                    b.Property<int>("DayID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InfluenceID")
                        .HasColumnType("int");

                    b.Property<int?>("MoodID")
                        .HasColumnType("int");

                    b.Property<int?>("NoteID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("DayID");

                    b.HasIndex("InfluenceID");

                    b.HasIndex("MoodID");

                    b.HasIndex("NoteID");

                    b.HasIndex("UserID");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("MBStest01.Models.Influence", b =>
                {
                    b.Property<int>("InfluenceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InfluenceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InfluenceID");

                    b.ToTable("Influences");
                });

            modelBuilder.Entity("MBStest01.Models.Mood", b =>
                {
                    b.Property<int>("MoodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MoodName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MoodID");

                    b.ToTable("Moods");
                });

            modelBuilder.Entity("MBStest01.Models.Note", b =>
                {
                    b.Property<int>("NoteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NoteString")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NoteID");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("MBStest01.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MBStest01.Models.Day", b =>
                {
                    b.HasOne("MBStest01.Models.Influence", "Influence")
                        .WithMany()
                        .HasForeignKey("InfluenceID");

                    b.HasOne("MBStest01.Models.Mood", "Mood")
                        .WithMany()
                        .HasForeignKey("MoodID");

                    b.HasOne("MBStest01.Models.Note", "Note")
                        .WithMany()
                        .HasForeignKey("NoteID");

                    b.HasOne("MBStest01.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Influence");

                    b.Navigation("Mood");

                    b.Navigation("Note");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}