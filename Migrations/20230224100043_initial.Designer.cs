﻿// <auto-generated />
using System;
using MaturaToBzdura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MaturaToBzdura.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230224100043_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MaturaToBzdura.Models.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("HSClassId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HSClassId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("MaturaToBzdura.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("ChapterId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("MaturaToBzdura.Models.HSClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HSClass");
                });

            modelBuilder.Entity("MaturaToBzdura.Models.Chapter", b =>
                {
                    b.HasOne("MaturaToBzdura.Models.HSClass", "HSClass")
                        .WithMany("Chapters")
                        .HasForeignKey("HSClassId");

                    b.Navigation("HSClass");
                });

            modelBuilder.Entity("MaturaToBzdura.Models.Exercise", b =>
                {
                    b.HasOne("MaturaToBzdura.Models.Chapter", "Chapter")
                        .WithMany("Exercises")
                        .HasForeignKey("ChapterId");

                    b.Navigation("Chapter");
                });

            modelBuilder.Entity("MaturaToBzdura.Models.Chapter", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("MaturaToBzdura.Models.HSClass", b =>
                {
                    b.Navigation("Chapters");
                });
#pragma warning restore 612, 618
        }
    }
}
