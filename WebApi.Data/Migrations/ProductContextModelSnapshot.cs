﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Data;

namespace WebApi.Data.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi.Domain.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ImgUri")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("841796d4-80b8-484a-9a66-7bccd0c4f296"),
                            Description = "Speed of transfer up to 200MB/s",
                            ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f4&cd=SASC022i1&i=1.jpg",
                            Name = "USB Flash Disk",
                            Price = 299m
                        },
                        new
                        {
                            Id = new Guid("2136eaad-4d96-435c-abcc-7a3b549cfcdd"),
                            ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=FotoAddOrig&cd=MC001b1-02&i=1.jpg",
                            Name = "Keyboard",
                            Price = 390m
                        },
                        new
                        {
                            Id = new Guid("271ff3fa-6952-4d54-ab57-b525f4fbd66b"),
                            Description = "Battery life up to 9 months",
                            ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f4&cd=ME362d2&i=1.jpg",
                            Name = "Mouse",
                            Price = 599m
                        },
                        new
                        {
                            Id = new Guid("eefbcc21-72fd-41a0-a4c9-132f1acec395"),
                            ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f4&cd=NA626d65&i=1.jpg",
                            Name = "Notebook",
                            Price = 31990m
                        },
                        new
                        {
                            Id = new Guid("74f5110e-fdc7-4137-b064-bafadc64b43a"),
                            ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f4&cd=SAMO0163b3&i=1.jpg",
                            Name = "Mobile Phone",
                            Price = 6999m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}