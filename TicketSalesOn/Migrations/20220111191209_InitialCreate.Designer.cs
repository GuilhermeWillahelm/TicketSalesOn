﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketSalesOn.Models;

#nullable disable

namespace TicketSalesOn.Migrations
{
    [DbContext(typeof(TicketSalesContext))]
    [Migration("20220111191209_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TicketSalesOn.Models.MovieChair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NameChair")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MovieChairs");
                });

            modelBuilder.Entity("TicketSalesOn.Models.Movies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NameMovie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PremiereDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PreviewDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("TicketSalesOn.Models.MovieTheatreNetwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("NameNetwork")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MovieTheatres");
                });

            modelBuilder.Entity("TicketSalesOn.Models.MovieTimes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Schedules")
                        .HasColumnType("datetime2");

                    b.Property<int?>("moviesId")
                        .HasColumnType("int");

                    b.Property<int?>("roomsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("moviesId");

                    b.HasIndex("roomsId");

                    b.ToTable("MoviesTimes");
                });

            modelBuilder.Entity("TicketSalesOn.Models.Rooms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Map")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MovieChairId")
                        .HasColumnType("int");

                    b.Property<int?>("MovieTheatreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieChairId");

                    b.HasIndex("MovieTheatreId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("TicketSalesOn.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("MovieTimesId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomsId")
                        .HasColumnType("int");

                    b.Property<string>("TicketType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.Property<int>("state")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieTimesId");

                    b.HasIndex("RoomsId");

                    b.HasIndex("UsersId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("TicketSalesOn.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TicketSalesOn.Models.MovieTimes", b =>
                {
                    b.HasOne("TicketSalesOn.Models.Movies", "movies")
                        .WithMany()
                        .HasForeignKey("moviesId");

                    b.HasOne("TicketSalesOn.Models.Rooms", "rooms")
                        .WithMany()
                        .HasForeignKey("roomsId");

                    b.Navigation("movies");

                    b.Navigation("rooms");
                });

            modelBuilder.Entity("TicketSalesOn.Models.Rooms", b =>
                {
                    b.HasOne("TicketSalesOn.Models.MovieChair", "MovieChair")
                        .WithMany()
                        .HasForeignKey("MovieChairId");

                    b.HasOne("TicketSalesOn.Models.MovieTheatreNetwork", "MovieTheatre")
                        .WithMany()
                        .HasForeignKey("MovieTheatreId");

                    b.Navigation("MovieChair");

                    b.Navigation("MovieTheatre");
                });

            modelBuilder.Entity("TicketSalesOn.Models.ShoppingCart", b =>
                {
                    b.HasOne("TicketSalesOn.Models.MovieTimes", "MovieTimes")
                        .WithMany()
                        .HasForeignKey("MovieTimesId");

                    b.HasOne("TicketSalesOn.Models.Rooms", "Rooms")
                        .WithMany()
                        .HasForeignKey("RoomsId");

                    b.HasOne("TicketSalesOn.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");

                    b.Navigation("MovieTimes");

                    b.Navigation("Rooms");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}