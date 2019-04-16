﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pharmacy.Infrastructure.EF;

namespace Pharmacy.Infrastructure.Migrations
{
    [DbContext(typeof(PharmacyContext))]
    [Migration("20190415192758_AddProperties")]
    partial class AddProperties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pharmacy.Core.Models.Medicament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EanCode");

                    b.Property<bool>("IsRefunded");

                    b.Property<string>("Name");

                    b.Property<int>("PercentageOfRefund");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.ToTable("Medicaments");
                });

            modelBuilder.Entity("Pharmacy.Core.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateOfFinalization");

                    b.Property<DateTime>("DateOfIssue");

                    b.Property<Guid>("PharmacistId");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("PharmacistId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Pharmacy.Core.Models.OrderElement", b =>
                {
                    b.Property<Guid>("MedicamentId");

                    b.Property<Guid>("OrderId");

                    b.Property<int>("Quantity");

                    b.HasKey("MedicamentId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderElements");
                });

            modelBuilder.Entity("Pharmacy.Core.Models.Prescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressOfThePatient");

                    b.Property<DateTime?>("DateOfFinalization");

                    b.Property<DateTime>("DateOfIssue");

                    b.Property<string>("LicenseNumberOfTheDoctor");

                    b.Property<string>("NameOfTheDoctor");

                    b.Property<string>("NameOfThePatient");

                    b.Property<string>("NipOrRegonOfTheProvider");

                    b.Property<string>("PeselNumberOfThePatient");

                    b.Property<Guid>("PharmacistId");

                    b.Property<string>("Provider");

                    b.Property<string>("SpecializationOfTheDoctor");

                    b.Property<string>("SurnameOfTheDoctor");

                    b.Property<string>("SurnameOfThePatient");

                    b.HasKey("Id");

                    b.HasIndex("PharmacistId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("Pharmacy.Core.Models.PrescriptionElement", b =>
                {
                    b.Property<Guid>("MedicamentId");

                    b.Property<Guid>("PrescriptionId");

                    b.Property<string>("Dosage");

                    b.Property<int>("Quantity");

                    b.HasKey("MedicamentId", "PrescriptionId");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("PrescriptionElements");
                });

            modelBuilder.Entity("Pharmacy.Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Education");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("Password");

                    b.Property<string>("PeselNumber");

                    b.Property<string>("Role");

                    b.Property<string>("Salt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Pharmacy.Core.Models.Order", b =>
                {
                    b.HasOne("Pharmacy.Core.Models.User", "Pharmacist")
                        .WithMany()
                        .HasForeignKey("PharmacistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pharmacy.Core.Models.OrderElement", b =>
                {
                    b.HasOne("Pharmacy.Core.Models.Medicament", "Medicament")
                        .WithMany("OrderElements")
                        .HasForeignKey("MedicamentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pharmacy.Core.Models.Order", "Order")
                        .WithMany("Elements")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pharmacy.Core.Models.Prescription", b =>
                {
                    b.HasOne("Pharmacy.Core.Models.User", "Pharmacist")
                        .WithMany()
                        .HasForeignKey("PharmacistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Pharmacy.Core.Models.PrescriptionElement", b =>
                {
                    b.HasOne("Pharmacy.Core.Models.Medicament", "Medicament")
                        .WithMany("PrescriptionElements")
                        .HasForeignKey("MedicamentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pharmacy.Core.Models.Prescription", "Prescription")
                        .WithMany("Elements")
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
