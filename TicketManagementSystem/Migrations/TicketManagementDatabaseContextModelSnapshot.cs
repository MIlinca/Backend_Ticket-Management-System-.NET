﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicketManagementSystem.Models;

#nullable disable

namespace TicketManagementSystem.Migrations
{
    [DbContext(typeof(TicketManagementDatabaseContext))]
    partial class TicketManagementDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TicketManagementSystem.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<string>("CustomerName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__A4AE64B8BCEC2659");

                    b.HasIndex(new[] { "Email" }, "UQ__Customer__A9D105344171A977")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("TicketManagementSystem.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("EndDate")
                        .HasPrecision(6)
                        .HasColumnType("datetime2(6)");

                    b.Property<int>("EventTypeId")
                        .HasColumnType("int")
                        .HasColumnName("EventTypeID");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("StartDate")
                        .HasPrecision(6)
                        .HasColumnType("datetime2(6)");

                    b.Property<int>("VenueId")
                        .HasColumnType("int")
                        .HasColumnName("VenueID");

                    b.HasKey("EventId")
                        .HasName("PK__Event__7944C87065CCC6E6");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("VenueId");

                    b.ToTable("Event", (string)null);
                });

            modelBuilder.Entity("TicketManagementSystem.Models.EventType", b =>
                {
                    b.Property<int>("EventTypeId")
                        .HasColumnType("int")
                        .HasColumnName("EventTypeID");

                    b.Property<string>("EventTypeName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("EventTypeId")
                        .HasName("PK__EventTyp__A9216B1FFBB52F4F");

                    b.HasIndex(new[] { "EventTypeName" }, "UQ__EventTyp__29BD765F33AD0FED")
                        .IsUnique()
                        .HasFilter("[EventTypeName] IS NOT NULL");

                    b.ToTable("EventType", (string)null);
                });

            modelBuilder.Entity("TicketManagementSystem.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<string>("NumberOfTickets")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("OrderedAt")
                        .HasPrecision(6)
                        .HasColumnType("datetime2(6)");

                    b.Property<int>("TicketCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("TicketCategoryID");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("numeric(38, 2)");

                    b.HasKey("OrderId")
                        .HasName("PK__Orders__C3905BAF3B712318");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TicketCategoryId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TicketManagementSystem.Models.TicketCategory", b =>
                {
                    b.Property<int>("TicketCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("TicketCategoryID");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    b.Property<long?>("Price")
                        .HasColumnType("bigint");

                    b.HasKey("TicketCategoryId")
                        .HasName("PK__TicketCa__C84589C61703A49C");

                    b.HasIndex("EventId");

                    b.ToTable("TicketCategory", (string)null);
                });

            modelBuilder.Entity("TicketManagementSystem.Models.Venue", b =>
                {
                    b.Property<int>("VenueId")
                        .HasColumnType("int")
                        .HasColumnName("VenueID");

                    b.Property<long?>("Capacity")
                        .HasColumnType("bigint");

                    b.Property<string>("Location")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Type")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("VenueId")
                        .HasName("PK__Venue__3C57E5D27E1FC8DF");

                    b.ToTable("Venue", (string)null);
                });

            modelBuilder.Entity("TicketManagementSystem.Models.Event", b =>
                {
                    b.HasOne("TicketManagementSystem.Models.EventType", "EventType")
                        .WithMany("Events")
                        .HasForeignKey("EventTypeId")
                        .IsRequired()
                        .HasConstraintName("FK__Event__EventType__5535A963");

                    b.HasOne("TicketManagementSystem.Models.Venue", "Venue")
                        .WithMany("Events")
                        .HasForeignKey("VenueId")
                        .IsRequired()
                        .HasConstraintName("FK__Event__VenueID__5441852A");

                    b.Navigation("EventType");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("TicketManagementSystem.Models.Order", b =>
                {
                    b.HasOne("TicketManagementSystem.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK__Orders__Customer__5AEE82B9");

                    b.HasOne("TicketManagementSystem.Models.TicketCategory", "TicketCategory")
                        .WithMany("Orders")
                        .HasForeignKey("TicketCategoryId")
                        .IsRequired()
                        .HasConstraintName("FK__Orders__TicketCa__5BE2A6F2");

                    b.Navigation("Customer");

                    b.Navigation("TicketCategory");
                });

            modelBuilder.Entity("TicketManagementSystem.Models.TicketCategory", b =>
                {
                    b.HasOne("TicketManagementSystem.Models.Event", "Event")
                        .WithMany("TicketCategories")
                        .HasForeignKey("EventId")
                        .IsRequired()
                        .HasConstraintName("FK__TicketCat__Event__5812160E");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("TicketManagementSystem.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TicketManagementSystem.Models.Event", b =>
                {
                    b.Navigation("TicketCategories");
                });

            modelBuilder.Entity("TicketManagementSystem.Models.EventType", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("TicketManagementSystem.Models.TicketCategory", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("TicketManagementSystem.Models.Venue", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
