﻿// <auto-generated />
using System;
using DevStudyNotes.API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DevStudyNotes.API.Persistence.Migrations
{
    [DbContext(typeof(StudyNoteDbContext))]
    partial class StudyNoteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("DevStudyNotes.API.Entities.StudyNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StudyNotes");
                });

            modelBuilder.Entity("DevStudyNotes.API.Entities.StudyNoteReaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPositive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudyNoteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudyNoteId");

                    b.ToTable("StudyNotesReactions");
                });

            modelBuilder.Entity("DevStudyNotes.API.Entities.StudyNoteReaction", b =>
                {
                    b.HasOne("DevStudyNotes.API.Entities.StudyNote", null)
                        .WithMany("Reactions")
                        .HasForeignKey("StudyNoteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("DevStudyNotes.API.Entities.StudyNote", b =>
                {
                    b.Navigation("Reactions");
                });
#pragma warning restore 612, 618
        }
    }
}
