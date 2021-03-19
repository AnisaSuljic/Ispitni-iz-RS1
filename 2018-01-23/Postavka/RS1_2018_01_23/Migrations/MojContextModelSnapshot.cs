﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RS1_2018_01_23.EF;
using RS1_2018_01_23.EntityModels;
using System;

namespace RS1_2018_01_23.Migrations
{
    [DbContext(typeof(MojContext))]
    partial class MojContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RS1_2018_01_23.EntityModels.LabPretraga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MjernaJedinica");

                    b.Property<string>("Naziv");

                    b.Property<double?>("ReferentnaVrijednostMax");

                    b.Property<double?>("ReferentnaVrijednostMin");

                    b.Property<int>("VrstaPretrageId");

                    b.Property<int>("VrstaVr");

                    b.HasKey("Id");

                    b.HasIndex("VrstaPretrageId");

                    b.ToTable("LabPretraga");
                });

            modelBuilder.Entity("RS1_2018_01_23.EntityModels.Ljekar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.HasKey("Id");

                    b.ToTable("Ljekar");
                });

            modelBuilder.Entity("RS1_2018_01_23.EntityModels.Modalitet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsReferentnaVrijednost");

                    b.Property<int>("LabPretragaId");

                    b.Property<string>("Opis");

                    b.HasKey("Id");

                    b.HasIndex("LabPretragaId");

                    b.ToTable("Modalitet");
                });

            modelBuilder.Entity("RS1_2018_01_23.EntityModels.Pacijent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<string>("Jmbg");

                    b.HasKey("Id");

                    b.ToTable("Pacijent");
                });

            modelBuilder.Entity("RS1_2018_01_23.EntityModels.RezultatPretrage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LabPretragaId");

                    b.Property<int?>("ModalitetId");

                    b.Property<double?>("NumerickaVrijednost");

                    b.Property<int>("UputnicaId");

                    b.HasKey("Id");

                    b.HasIndex("LabPretragaId");

                    b.HasIndex("ModalitetId");

                    b.HasIndex("UputnicaId");

                    b.ToTable("RezultatPretrage");
                });

            modelBuilder.Entity("RS1_2018_01_23.EntityModels.Uputnica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DatumRezultata");

                    b.Property<DateTime>("DatumUputnice");

                    b.Property<bool>("IsGotovNalaz");

                    b.Property<int?>("LaboratorijLjekarId");

                    b.Property<int>("PacijentId");

                    b.Property<int>("UputioLjekarId");

                    b.Property<int>("VrstaPretrageId");

                    b.HasKey("Id");

                    b.HasIndex("LaboratorijLjekarId");

                    b.HasIndex("PacijentId");

                    b.HasIndex("UputioLjekarId");

                    b.HasIndex("VrstaPretrageId");

                    b.ToTable("Uputnica");
                });

            modelBuilder.Entity("RS1_2018_01_23.EntityModels.VrstaPretrage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("VrstaPretrage");
                });

            modelBuilder.Entity("RS1_2018_01_23.EntityModels.LabPretraga", b =>
                {
                    b.HasOne("RS1_2018_01_23.EntityModels.VrstaPretrage", "VrstaPretrage")
                        .WithMany()
                        .HasForeignKey("VrstaPretrageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS1_2018_01_23.EntityModels.Modalitet", b =>
                {
                    b.HasOne("RS1_2018_01_23.EntityModels.LabPretraga", "LabPretraga")
                        .WithMany()
                        .HasForeignKey("LabPretragaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS1_2018_01_23.EntityModels.RezultatPretrage", b =>
                {
                    b.HasOne("RS1_2018_01_23.EntityModels.LabPretraga", "LabPretraga")
                        .WithMany()
                        .HasForeignKey("LabPretragaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_2018_01_23.EntityModels.Modalitet", "Modalitet")
                        .WithMany()
                        .HasForeignKey("ModalitetId");

                    b.HasOne("RS1_2018_01_23.EntityModels.Uputnica", "Uputnica")
                        .WithMany()
                        .HasForeignKey("UputnicaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("RS1_2018_01_23.EntityModels.Uputnica", b =>
                {
                    b.HasOne("RS1_2018_01_23.EntityModels.Ljekar", "LaboratorijLjekar")
                        .WithMany()
                        .HasForeignKey("LaboratorijLjekarId");

                    b.HasOne("RS1_2018_01_23.EntityModels.Pacijent", "Pacijent")
                        .WithMany()
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_2018_01_23.EntityModels.Ljekar", "UputioLjekar")
                        .WithMany()
                        .HasForeignKey("UputioLjekarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS1_2018_01_23.EntityModels.VrstaPretrage", "VrstaPretrage")
                        .WithMany()
                        .HasForeignKey("VrstaPretrageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}