﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using testingproj.Models;

namespace testingproj.Migrations
{
    [DbContext(typeof(testingprojContext))]
    [Migration("20200426205509_photopath1")]
    partial class photopath1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("testingproj.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FoodName");

                    b.HasKey("FoodId");

                    b.ToTable("foods");
                });

            modelBuilder.Entity("testingproj.Models.aziz", b =>
                {
                    b.Property<int>("azizId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("azizName");

                    b.HasKey("azizId");

                    b.ToTable("aziz");
                });

            modelBuilder.Entity("testingproj.Models.check", b =>
                {
                    b.Property<int>("checkId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("checkName");

                    b.HasKey("checkId");

                    b.ToTable("check");
                });

            modelBuilder.Entity("testingproj.Models.myfoods", b =>
                {
                    b.Property<int>("myfoodsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price");

                    b.Property<int>("foodCalories")
                        .HasMaxLength(3);

                    b.Property<string>("myfoodsName")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("photopath");

                    b.Property<string>("photopath11");

                    b.HasKey("myfoodsId");

                    b.ToTable("Myfoods");
                });

            modelBuilder.Entity("testingproj.Models.nori", b =>
                {
                    b.Property<int>("noriId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("noriName");

                    b.HasKey("noriId");

                    b.ToTable("nori");
                });
#pragma warning restore 612, 618
        }
    }
}
