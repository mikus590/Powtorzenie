﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ClientDbContext))]
    partial class ClientDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.Klient", b =>
                {
                    b.Property<int>("IdKlient")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .HasMaxLength(50);

                    b.Property<int>("Nazwisko")
                        .HasMaxLength(60);

                    b.HasKey("IdKlient");

                    b.ToTable("Klienci");
                });

            modelBuilder.Entity("WebApplication1.Models.Pracownik", b =>
                {
                    b.Property<int>("IdPracownik")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imie")
                        .HasMaxLength(50);

                    b.Property<int>("Nazwisko")
                        .HasMaxLength(60);

                    b.HasKey("IdPracownik");

                    b.ToTable("Pracownik");
                });

            modelBuilder.Entity("WebApplication1.Models.WyrobCukierniczy", b =>
                {
                    b.Property<int>("IdWyrobCukierniczy")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("CenaZaSzt");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Typ");

                    b.HasKey("IdWyrobCukierniczy");

                    b.ToTable("WyrobCukierniczy");
                });

            modelBuilder.Entity("WebApplication1.Models.Zamowienie_WyrobCukierniczy", b =>
                {
                    b.Property<int>("IdZamowienia");

                    b.Property<int>("IdWyrobuCukierniczego");

                    b.Property<int>("Ilosc");

                    b.Property<string>("Uwagi")
                        .HasMaxLength(300);

                    b.HasKey("IdZamowienia", "IdWyrobuCukierniczego");

                    b.HasIndex("IdWyrobuCukierniczego");

                    b.ToTable("ZamowienieWyrob");
                });

            modelBuilder.Entity("WebApplication1.Models.Zamówienie", b =>
                {
                    b.Property<int>("IdZamówienia")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataPrzyjecia");

                    b.Property<DateTime?>("DataRealizacji");

                    b.Property<int>("IdKlient");

                    b.Property<int>("IdPracownik");

                    b.Property<string>("Uwagi")
                        .HasMaxLength(300);

                    b.HasKey("IdZamówienia");

                    b.HasIndex("IdKlient");

                    b.HasIndex("IdPracownik");

                    b.ToTable("Zamówienia");
                });

            modelBuilder.Entity("WebApplication1.Models.Zamowienie_WyrobCukierniczy", b =>
                {
                    b.HasOne("WebApplication1.Models.WyrobCukierniczy", "Wyrob")
                        .WithMany("ZamowienieWyrob")
                        .HasForeignKey("IdWyrobuCukierniczego")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Models.Zamówienie", "Zamowienie")
                        .WithMany("ZamowienieWyrob")
                        .HasForeignKey("IdZamowienia")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.Models.Zamówienie", b =>
                {
                    b.HasOne("WebApplication1.Models.Klient", "Klient")
                        .WithMany("Zamowienia")
                        .HasForeignKey("IdKlient")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Models.Pracownik", "Pracownik")
                        .WithMany("Zamowienia")
                        .HasForeignKey("IdPracownik")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
