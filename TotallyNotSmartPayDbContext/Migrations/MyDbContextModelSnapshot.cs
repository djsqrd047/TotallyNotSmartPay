﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TotallyNotSmartPayDbContext;

namespace TotallyNotSmartPayDbContext.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("TotallyNotSmartPayModels.StoreInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RINId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SINId")
                        .HasColumnType("int");

                    b.Property<int>("StoreNumber")
                        .HasColumnType("int");

                    b.Property<int>("VINId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StoreInformation");
                });
#pragma warning restore 612, 618
        }
    }
}
