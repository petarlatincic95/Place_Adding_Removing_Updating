﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Place_Adding_Removing_Updating.Data;

#nullable disable

namespace Place_Adding_Removing_Updating.Migrations
{
    [DbContext(typeof(dbContext))]
    partial class dbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Place_Adding_Removing_Updating.Data.Model.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Place_Adding_Removing_Updating.Data.Model.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("ZipCode")
                        .IsUnique()
                        .HasFilter("[ZipCode] IS NOT NULL");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Place_Adding_Removing_Updating.Data.Model.Place", b =>
                {
                    b.HasOne("Place_Adding_Removing_Updating.Data.Model.Country", "Country")
                        .WithMany("PlaceList")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Place_Adding_Removing_Updating.Data.Model.Country", b =>
                {
                    b.Navigation("PlaceList");
                });
#pragma warning restore 612, 618
        }
    }
}