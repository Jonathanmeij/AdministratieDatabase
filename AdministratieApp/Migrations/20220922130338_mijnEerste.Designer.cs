﻿// <auto-generated />
using System;
using AdminstratieApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdministratieApp.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220922130338_mijnEerste")]
    partial class mijnEerste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("AdminstratieApp.Attractie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ReserveringId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ReserveringId");

                    b.ToTable("Attracties");
                });

            modelBuilder.Entity("AdminstratieApp.GastInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GastId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LaatstBezochteURL")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GastId")
                        .IsUnique();

                    b.ToTable("GastInfos");
                });

            modelBuilder.Entity("AdminstratieApp.Gebruiker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Gebruikers", (string)null);
                });

            modelBuilder.Entity("AdminstratieApp.Onderhoud", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AttractieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Probleem")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AttractieId");

                    b.ToTable("Onderhoud");
                });

            modelBuilder.Entity("AdminstratieApp.Reservering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GastId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GastId");

                    b.ToTable("Reserveringen");
                });

            modelBuilder.Entity("MedewerkerOnderhoud", b =>
                {
                    b.Property<int>("CoordinatorOnderhoudId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoordinatorenId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CoordinatorOnderhoudId", "CoordinatorenId");

                    b.HasIndex("CoordinatorenId");

                    b.ToTable("MedewerkerOnderhoud");
                });

            modelBuilder.Entity("MedewerkerOnderhoud1", b =>
                {
                    b.Property<int>("UitvoerderOnderhoudId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UitvoerdersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UitvoerderOnderhoudId", "UitvoerdersId");

                    b.HasIndex("UitvoerdersId");

                    b.ToTable("MedewerkerOnderhoud1");
                });

            modelBuilder.Entity("AdminstratieApp.Gast", b =>
                {
                    b.HasBaseType("AdminstratieApp.Gebruiker");

                    b.Property<int?>("BegeleiderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EersteBezoek")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FavorietId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("GeboorteDatum")
                        .HasColumnType("TEXT");

                    b.HasIndex("BegeleiderId");

                    b.HasIndex("FavorietId");

                    b.ToTable("Gasten", (string)null);
                });

            modelBuilder.Entity("AdminstratieApp.Medewerker", b =>
                {
                    b.HasBaseType("AdminstratieApp.Gebruiker");

                    b.ToTable("Medewerkers", (string)null);
                });

            modelBuilder.Entity("AdminstratieApp.Attractie", b =>
                {
                    b.HasOne("AdminstratieApp.Reservering", "Reservering")
                        .WithMany("Attracties")
                        .HasForeignKey("ReserveringId");

                    b.Navigation("Reservering");
                });

            modelBuilder.Entity("AdminstratieApp.GastInfo", b =>
                {
                    b.HasOne("AdminstratieApp.Gast", "Gast")
                        .WithOne("gastInfo")
                        .HasForeignKey("AdminstratieApp.GastInfo", "GastId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("AdminstratieApp.Coordinate", "Coordinate", b1 =>
                        {
                            b1.Property<int>("GastInfoId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("X")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Y")
                                .HasColumnType("INTEGER");

                            b1.HasKey("GastInfoId");

                            b1.ToTable("GastInfos");

                            b1.WithOwner()
                                .HasForeignKey("GastInfoId");
                        });

                    b.Navigation("Coordinate")
                        .IsRequired();

                    b.Navigation("Gast");
                });

            modelBuilder.Entity("AdminstratieApp.Onderhoud", b =>
                {
                    b.HasOne("AdminstratieApp.Attractie", "Attractie")
                        .WithMany("OnderhoudsBeurten")
                        .HasForeignKey("AttractieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("AdminstratieApp.DateTimeBereik", "DateTimeBereik", b1 =>
                        {
                            b1.Property<int>("OnderhoudId")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime>("Begin")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("Eind")
                                .HasColumnType("TEXT");

                            b1.HasKey("OnderhoudId");

                            b1.ToTable("Onderhoud");

                            b1.WithOwner()
                                .HasForeignKey("OnderhoudId");
                        });

                    b.Navigation("Attractie");

                    b.Navigation("DateTimeBereik")
                        .IsRequired();
                });

            modelBuilder.Entity("AdminstratieApp.Reservering", b =>
                {
                    b.HasOne("AdminstratieApp.Gast", null)
                        .WithMany("Reserveringen")
                        .HasForeignKey("GastId");

                    b.OwnsOne("AdminstratieApp.DateTimeBereik", "DateTimeBereik", b1 =>
                        {
                            b1.Property<int>("ReserveringId")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime>("Begin")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("Eind")
                                .HasColumnType("TEXT");

                            b1.HasKey("ReserveringId");

                            b1.ToTable("Reserveringen");

                            b1.WithOwner()
                                .HasForeignKey("ReserveringId");
                        });

                    b.Navigation("DateTimeBereik")
                        .IsRequired();
                });

            modelBuilder.Entity("MedewerkerOnderhoud", b =>
                {
                    b.HasOne("AdminstratieApp.Onderhoud", null)
                        .WithMany()
                        .HasForeignKey("CoordinatorOnderhoudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdminstratieApp.Medewerker", null)
                        .WithMany()
                        .HasForeignKey("CoordinatorenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedewerkerOnderhoud1", b =>
                {
                    b.HasOne("AdminstratieApp.Onderhoud", null)
                        .WithMany()
                        .HasForeignKey("UitvoerderOnderhoudId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdminstratieApp.Medewerker", null)
                        .WithMany()
                        .HasForeignKey("UitvoerdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdminstratieApp.Gast", b =>
                {
                    b.HasOne("AdminstratieApp.Gast", "Begeleider")
                        .WithMany()
                        .HasForeignKey("BegeleiderId");

                    b.HasOne("AdminstratieApp.Attractie", "Favoriet")
                        .WithMany("Gasten")
                        .HasForeignKey("FavorietId");

                    b.HasOne("AdminstratieApp.Gebruiker", null)
                        .WithOne()
                        .HasForeignKey("AdminstratieApp.Gast", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Begeleider");

                    b.Navigation("Favoriet");
                });

            modelBuilder.Entity("AdminstratieApp.Medewerker", b =>
                {
                    b.HasOne("AdminstratieApp.Gebruiker", null)
                        .WithOne()
                        .HasForeignKey("AdminstratieApp.Medewerker", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdminstratieApp.Attractie", b =>
                {
                    b.Navigation("Gasten");

                    b.Navigation("OnderhoudsBeurten");
                });

            modelBuilder.Entity("AdminstratieApp.Reservering", b =>
                {
                    b.Navigation("Attracties");
                });

            modelBuilder.Entity("AdminstratieApp.Gast", b =>
                {
                    b.Navigation("Reserveringen");

                    b.Navigation("gastInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
