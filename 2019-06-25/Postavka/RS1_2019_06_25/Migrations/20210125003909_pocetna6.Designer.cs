﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RS1_2019_06_25.EF;
using System;

namespace RS1_2019_06_25.Migrations
{
    [DbContext(typeof(MojContext))]
    [Migration("20210125003909_pocetna6")]
    partial class pocetna6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.AkademskaGodina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Opis");

                    b.HasKey("Id");

                    b.ToTable("AkademskaGodina");
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.Angazovan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AkademskaGodinaId");

                    b.Property<int>("NastavnikId");

                    b.Property<int>("PredmetId");

                    b.HasKey("Id");

                    b.HasIndex("AkademskaGodinaId");

                    b.HasIndex("NastavnikId");

                    b.HasIndex("PredmetId");

                    b.ToTable("Angazovan");
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.IspitniTermin", b =>
                {
                    b.Property<int>("IspitniTerminID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AngazovanID");

                    b.Property<DateTime>("DatumIspita");

                    b.Property<string>("Napomena");

                    b.Property<bool>("Zakljucano");

                    b.HasKey("IspitniTerminID");

                    b.HasIndex("AngazovanID");

                    b.ToTable("IspitniTermin");
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.IspitniTerminStavke", b =>
                {
                    b.Property<int>("IspitniTerminStavkeID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsPristupio");

                    b.Property<int>("IspitniTerminID");

                    b.Property<int>("Ocjena");

                    b.Property<int>("StudentID");

                    b.HasKey("IspitniTerminStavkeID");

                    b.HasIndex("IspitniTerminID");

                    b.HasIndex("StudentID");

                    b.ToTable("IspitniTerminStavke");
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.Nastavnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Nastavnik");
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.OdrzaniCas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AngazovaniId");

                    b.Property<DateTime>("Datum");

                    b.HasKey("Id");

                    b.HasIndex("AngazovaniId");

                    b.ToTable("OdrzaniCas");
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.OdrzaniCasDetalji", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BodoviNaCasu");

                    b.Property<int>("OdrzaniCasoviId");

                    b.Property<bool>("Prisutan");

                    b.Property<int>("SlusaPredmeteId");

                    b.HasKey("Id");

                    b.HasIndex("OdrzaniCasoviId");

                    b.HasIndex("SlusaPredmeteId");

                    b.ToTable("OdrzaniCasDetalji");
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.Predmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ECTS");

                    b.Property<int>("Godina");

                    b.Property<string>("Naziv");

                    b.Property<int>("Sifra");

                    b.HasKey("Id");

                    b.ToTable("Predmet");
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.SlusaPredmet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AngazovanId");

                    b.Property<DateTime?>("DatumOcjene");

                    b.Property<int?>("Ocjena");

                    b.Property<int>("UpisGodineId");

                    b.HasKey("Id");

                    b.HasIndex("AngazovanId");

                    b.HasIndex("UpisGodineId");

                    b.ToTable("SlusaPredmet");
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrojIndeksa");

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.UpisGodine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AkademskaGodinaId");

                    b.Property<DateTime>("DatumUpisa");

                    b.Property<int>("GodinaStudija");

                    b.Property<int>("PolozioECTS");

                    b.Property<int>("SlusaECTS");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("AkademskaGodinaId");

                    b.HasIndex("StudentId");

                    b.ToTable("UpisGodine");
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.Angazovan", b =>
                {
                    b.HasOne("RS1_2019_06_25.EntityModels.AkademskaGodina", "AkademskaGodina")
                        .WithMany()
                        .HasForeignKey("AkademskaGodinaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_2019_06_25.EntityModels.Nastavnik", "Nastavnik")
                        .WithMany()
                        .HasForeignKey("NastavnikId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_2019_06_25.EntityModels.Predmet", "Predmet")
                        .WithMany()
                        .HasForeignKey("PredmetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.IspitniTermin", b =>
                {
                    b.HasOne("RS1_2019_06_25.EntityModels.Angazovan", "Angazovan")
                        .WithMany()
                        .HasForeignKey("AngazovanID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.IspitniTerminStavke", b =>
                {
                    b.HasOne("RS1_2019_06_25.EntityModels.IspitniTermin", "IspitniTermin")
                        .WithMany()
                        .HasForeignKey("IspitniTerminID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_2019_06_25.EntityModels.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.OdrzaniCas", b =>
                {
                    b.HasOne("RS1_2019_06_25.EntityModels.Angazovan", "Angazovani")
                        .WithMany()
                        .HasForeignKey("AngazovaniId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.OdrzaniCasDetalji", b =>
                {
                    b.HasOne("RS1_2019_06_25.EntityModels.OdrzaniCas", "OdrzaniCasovi")
                        .WithMany()
                        .HasForeignKey("OdrzaniCasoviId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_2019_06_25.EntityModels.SlusaPredmet", "SlusaPredmete")
                        .WithMany()
                        .HasForeignKey("SlusaPredmeteId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.SlusaPredmet", b =>
                {
                    b.HasOne("RS1_2019_06_25.EntityModels.Angazovan", "Angazovan")
                        .WithMany()
                        .HasForeignKey("AngazovanId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_2019_06_25.EntityModels.UpisGodine", "UpisGodine")
                        .WithMany()
                        .HasForeignKey("UpisGodineId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("RS1_2019_06_25.EntityModels.UpisGodine", b =>
                {
                    b.HasOne("RS1_2019_06_25.EntityModels.AkademskaGodina", "AkademskaGodina")
                        .WithMany()
                        .HasForeignKey("AkademskaGodinaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_2019_06_25.EntityModels.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
