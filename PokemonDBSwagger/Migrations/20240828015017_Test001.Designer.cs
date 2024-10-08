﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokemonDBSwagger.Data;

#nullable disable

namespace PokemonDBSwagger.Migrations
{
    [DbContext(typeof(APIDBContext))]
    [Migration("20240828015017_Test001")]
    partial class Test001
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PokemonDBSwagger.Models.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PokedexNumber")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("PokemonName")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("PokemonTitle")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("TypeAId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("TypeBId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeAId");

                    b.HasIndex("TypeBId");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("PokemonDBSwagger.Models.PokemonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeName")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<byte>("againstBug")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstDark")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstDragon")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstElectric")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstFairy")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstFighting")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstFire")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstFlying")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstGhost")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstGrass")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstGround")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstIce")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstNormal")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstPoison")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstPsychic")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstRock")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstSteel")
                        .HasColumnType("tinyint");

                    b.Property<byte>("againstWater")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("PokemonTypes");
                });

            modelBuilder.Entity("PokemonDBSwagger.Models.Pokemon", b =>
                {
                    b.HasOne("PokemonDBSwagger.Models.PokemonType", "TypeA")
                        .WithMany()
                        .HasForeignKey("TypeAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokemonDBSwagger.Models.PokemonType", "TypeB")
                        .WithMany()
                        .HasForeignKey("TypeBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeA");

                    b.Navigation("TypeB");
                });
#pragma warning restore 612, 618
        }
    }
}
