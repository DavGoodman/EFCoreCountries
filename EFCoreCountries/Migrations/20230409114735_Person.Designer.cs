﻿// <auto-generated />
using System;
using EFCoreCountries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreCountries.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230409114735_Person")]
    partial class Person
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCoreCountries.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GovernmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("Population")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GovernmentId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GovernmentId = 4,
                            Name = "Norway",
                            Population = 5400000
                        },
                        new
                        {
                            Id = 2,
                            GovernmentId = 2,
                            Name = "Iceland",
                            Population = 370000
                        },
                        new
                        {
                            Id = 3,
                            GovernmentId = 2,
                            Name = "Hungary",
                            Population = 9700000
                        },
                        new
                        {
                            Id = 4,
                            GovernmentId = 5,
                            Name = "China",
                            Population = 1412400000
                        },
                        new
                        {
                            Id = 5,
                            GovernmentId = 1,
                            Name = "USA",
                            Population = 332000000
                        });
                });

            modelBuilder.Entity("EFCoreCountries.Entities.CountryLanguage", b =>
                {
                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("CountryId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("CountriesLanguages");

                    b.HasData(
                        new
                        {
                            CountryId = 2,
                            LanguageId = 3
                        },
                        new
                        {
                            CountryId = 1,
                            LanguageId = 2
                        },
                        new
                        {
                            CountryId = 1,
                            LanguageId = 4
                        },
                        new
                        {
                            CountryId = 3,
                            LanguageId = 6
                        },
                        new
                        {
                            CountryId = 5,
                            LanguageId = 1
                        },
                        new
                        {
                            CountryId = 4,
                            LanguageId = 5
                        },
                        new
                        {
                            CountryId = 4,
                            LanguageId = 7
                        });
                });

            modelBuilder.Entity("EFCoreCountries.Entities.Government", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SystemDescription")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("SystemName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("SystemName")
                        .IsUnique();

                    b.ToTable("Governments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SystemDescription = "A presidential system, or single executive system, is a form of government in which a head of government, typically with the title of president, leads an executive branch that is separate from the legislative branch in systems that use separation of powers.",
                            SystemName = "Presidential Republic"
                        },
                        new
                        {
                            Id = 2,
                            SystemDescription = "A parliamentary republic is a republic that operates under a parliamentary system of government where the executive branch derives its legitimacy from and is accountable to the legislature.",
                            SystemName = "Parliamentary Republic"
                        },
                        new
                        {
                            Id = 3,
                            SystemDescription = "Absolute monarchy is a form of monarchy in which the monarch rules in their own right or power. In an absolute monarchy, the king or queen is by no means limited and has absolute power.",
                            SystemName = "Absolute Monarchy"
                        },
                        new
                        {
                            Id = 4,
                            SystemDescription = "A constitutional monarchy, parliamentary monarchy, or democratic monarchy is a form of monarchy in which the monarch exercises their authority in accordance with a constitution and is not alone in decision making.",
                            SystemName = "Constitutional Monarchy"
                        },
                        new
                        {
                            Id = 5,
                            SystemDescription = "A one-party state, single-party state, one-party system,de-facto one-party state or single-party system is a type of sovereign state in which only one political party has the right to form the government, usually based on the existing constitution.",
                            SystemName = "One Party State"
                        });
                });

            modelBuilder.Entity("EFCoreCountries.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageName")
                        .IsUnique();

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LanguageName = "English"
                        },
                        new
                        {
                            Id = 2,
                            LanguageName = "Norwegian"
                        },
                        new
                        {
                            Id = 3,
                            LanguageName = "Icelandic"
                        },
                        new
                        {
                            Id = 4,
                            LanguageName = "Sami"
                        },
                        new
                        {
                            Id = 5,
                            LanguageName = "Mandarin"
                        },
                        new
                        {
                            Id = 6,
                            LanguageName = "Hungarian"
                        },
                        new
                        {
                            Id = 7,
                            LanguageName = "Cantonese"
                        });
                });

            modelBuilder.Entity("EFCoreCountries.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("PersonType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<int>("PersonType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EFCoreCountries.Entities.Diplomat", b =>
                {
                    b.HasBaseType("EFCoreCountries.Entities.Person");

                    b.Property<int>("HostCountryId")
                        .HasColumnType("int");

                    b.HasIndex("CountryId")
                        .HasDatabaseName("IX_Persons_CountryId1");

                    b.HasIndex("HostCountryId");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("EFCoreCountries.Entities.Leader", b =>
                {
                    b.HasBaseType("EFCoreCountries.Entities.Person");

                    b.Property<string>("Party")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasIndex("CountryId")
                        .IsUnique()
                        .HasFilter("[CountryId] IS NOT NULL");

                    b.HasDiscriminator().HasValue(1);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 4,
                            Name = "Xi Jinping",
                            PersonType = 0,
                            Party = "Chinese Communist Party"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Jonas Gahr Støre",
                            PersonType = 0,
                            Party = "Labour Party"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 2,
                            Name = "Katrín Jakobsdóttir",
                            PersonType = 0,
                            Party = "Left Green"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 5,
                            Name = "Joe Biden",
                            PersonType = 0,
                            Party = "Democratic Party"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 3,
                            Name = "Orban Viktor",
                            PersonType = 0,
                            Party = "Fidesz"
                        });
                });

            modelBuilder.Entity("EFCoreCountries.Entities.Country", b =>
                {
                    b.HasOne("EFCoreCountries.Entities.Government", "Government")
                        .WithMany("Countries")
                        .HasForeignKey("GovernmentId");

                    b.Navigation("Government");
                });

            modelBuilder.Entity("EFCoreCountries.Entities.CountryLanguage", b =>
                {
                    b.HasOne("EFCoreCountries.Entities.Country", "Country")
                        .WithMany("CountriesLanguages")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreCountries.Entities.Language", "Language")
                        .WithMany("CountriesLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("EFCoreCountries.Entities.Diplomat", b =>
                {
                    b.HasOne("EFCoreCountries.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_Persons_Countries_CountryId1");

                    b.HasOne("EFCoreCountries.Entities.Country", "HostCountry")
                        .WithMany()
                        .HasForeignKey("HostCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("HostCountry");
                });

            modelBuilder.Entity("EFCoreCountries.Entities.Leader", b =>
                {
                    b.HasOne("EFCoreCountries.Entities.Country", "Country")
                        .WithOne("Leader")
                        .HasForeignKey("EFCoreCountries.Entities.Leader", "CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("EFCoreCountries.Entities.Country", b =>
                {
                    b.Navigation("CountriesLanguages");

                    b.Navigation("Leader");
                });

            modelBuilder.Entity("EFCoreCountries.Entities.Government", b =>
                {
                    b.Navigation("Countries");
                });

            modelBuilder.Entity("EFCoreCountries.Entities.Language", b =>
                {
                    b.Navigation("CountriesLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}
