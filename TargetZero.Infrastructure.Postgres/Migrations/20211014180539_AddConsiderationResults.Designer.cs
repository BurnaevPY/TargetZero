﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TargetZero.Infrastructure.Postgres;

namespace TargetZero.Infrastructure.Postgres.Migrations
{
    [DbContext(typeof(TargetZeroContext))]
    [Migration("20211014180539_AddConsiderationResults")]
    partial class AddConsiderationResults
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TargetZero.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TargetZero.Domain.Consideration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ConsiderationGroupId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int?>("ConsiderationResultId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int>("InnovationId")
                        .HasColumnType("integer");

                    b.Property<int?>("InnovationStatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasAlternateKey("InnovationId", "ConsiderationGroupId");

                    b.HasIndex("ConsiderationGroupId");

                    b.HasIndex("ConsiderationResultId");

                    b.HasIndex("InnovationStatusId");

                    b.ToTable("Considerations");
                });

            modelBuilder.Entity("TargetZero.Domain.ConsiderationGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ConsiderationGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Группа рассмотрения 1",
                            Name = "Group1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Группа рассмотрения 2",
                            Name = "Group2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Группа рассмотрения 3",
                            Name = "Group3"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Группа рассмотрения 4",
                            Name = "Group4"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Группа рассмотрения 5",
                            Name = "Group5"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Группа рассмотрения 6",
                            Name = "Group6"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Группа рассмотрения 7",
                            Name = "Group7"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Группа рассмотрения ГРНУ",
                            Name = "GrnuGroup"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Группа рассмотрения РРНУ",
                            Name = "RrnuGroup"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Группа рассмотрения МРНУ",
                            Name = "MrnuGroup"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Группа рассмотрения БПТОиКО",
                            Name = "BptoGroup"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Группа рассмотрения ТНМ",
                            Name = "TnmGroup"
                        },
                        new
                        {
                            Id = 13,
                            Description = "Группа рассмотрения ВРНПУ",
                            Name = "VrnpuGroup"
                        },
                        new
                        {
                            Id = 14,
                            Description = "Группа рассмотрения ЦПА",
                            Name = "TspaGroup"
                        });
                });

            modelBuilder.Entity("TargetZero.Domain.ConsiderationResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ConsiderationResults");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Вне зоны ответственности",
                            Name = "Consideration"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Принято",
                            Name = "Accepted"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Отклонено",
                            Name = "Rejected"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Уточнение",
                            Name = "Clarification"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Доработка",
                            Name = "Rework"
                        });
                });

            modelBuilder.Entity("TargetZero.Domain.Filial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Filials");

                    b.HasData(
                        new
                        {
                            Id = 8,
                            Name = "Общество"
                        },
                        new
                        {
                            Id = 9,
                            Name = "МРНУ"
                        },
                        new
                        {
                            Id = 10,
                            Name = "РРНУ"
                        },
                        new
                        {
                            Id = 11,
                            Name = "ГРНУ"
                        },
                        new
                        {
                            Id = 12,
                            Name = "ТНМ"
                        },
                        new
                        {
                            Id = 13,
                            Name = "БПТОиКО"
                        },
                        new
                        {
                            Id = 75,
                            Name = "ВРНПУ"
                        },
                        new
                        {
                            Id = 79,
                            Name = "ЦПА"
                        });
                });

            modelBuilder.Entity("TargetZero.Domain.Innovation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasIdentityOptions(100100L, null, null, null, null, null)
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<int?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CurrentState")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("FilialId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<int?>("InnovationStatusId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1);

                    b.Property<bool>("IsActual")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<string>("TargetState")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("FilialId");

                    b.HasIndex("InnovationStatusId");

                    b.ToTable("Innovations");
                });

            modelBuilder.Entity("TargetZero.Domain.InnovationStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("InnovationStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Рассмотрение",
                            Name = "Consideration"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Принято",
                            Name = "Accepted"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Отклонено",
                            Name = "Rejected"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Уточнение",
                            Name = "Clarification"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Доработка",
                            Name = "Rework"
                        });
                });

            modelBuilder.Entity("TargetZero.Domain.Resolution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Author")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ExecutionTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("InnovationId")
                        .HasColumnType("integer");

                    b.Property<int?>("InnovationStatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InnovationId");

                    b.HasIndex("InnovationStatusId");

                    b.ToTable("Resolutions");
                });

            modelBuilder.Entity("TargetZero.Domain.Consideration", b =>
                {
                    b.HasOne("TargetZero.Domain.ConsiderationGroup", "ConsiderationGroup")
                        .WithMany()
                        .HasForeignKey("ConsiderationGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TargetZero.Domain.ConsiderationResult", "ConsiderationResult")
                        .WithMany()
                        .HasForeignKey("ConsiderationResultId");

                    b.HasOne("TargetZero.Domain.Innovation", null)
                        .WithMany()
                        .HasForeignKey("InnovationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TargetZero.Domain.InnovationStatus", "InnovationStatus")
                        .WithMany()
                        .HasForeignKey("InnovationStatusId");

                    b.Navigation("ConsiderationGroup");

                    b.Navigation("ConsiderationResult");

                    b.Navigation("InnovationStatus");
                });

            modelBuilder.Entity("TargetZero.Domain.Innovation", b =>
                {
                    b.HasOne("TargetZero.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TargetZero.Domain.Filial", "Filial")
                        .WithMany()
                        .HasForeignKey("FilialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TargetZero.Domain.InnovationStatus", "InnovationStatus")
                        .WithMany()
                        .HasForeignKey("InnovationStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Filial");

                    b.Navigation("InnovationStatus");
                });

            modelBuilder.Entity("TargetZero.Domain.Resolution", b =>
                {
                    b.HasOne("TargetZero.Domain.Innovation", null)
                        .WithMany()
                        .HasForeignKey("InnovationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TargetZero.Domain.InnovationStatus", "InnovationStatus")
                        .WithMany()
                        .HasForeignKey("InnovationStatusId");

                    b.Navigation("InnovationStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
