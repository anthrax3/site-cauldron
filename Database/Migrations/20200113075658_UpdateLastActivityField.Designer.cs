﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiteCauldron.Database;

namespace SiteCauldron.Database.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20200113075658_UpdateLastActivityField")]
    partial class UpdateLastActivityField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SiteCauldron.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatePayment")
                        .HasColumnName("payment_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentPriceId")
                        .HasColumnName("payment_price_id")
                        .HasColumnType("int");

                    b.Property<string>("PaymentReference")
                        .HasColumnName("payment_reference")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentPriceId");

                    b.ToTable("payments");
                });

            modelBuilder.Entity("SiteCauldron.Models.PricesCatalogEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Currency")
                        .HasColumnName("currency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceCents")
                        .HasColumnName("price_cents")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("prices_catalog");
                });

            modelBuilder.Entity("SiteCauldron.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastActivity")
                        .HasColumnName("last_activity")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnName("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnName("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("SiteCauldron.Models.UserProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnName("date_created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateLastModified")
                        .HasColumnName("date_last_modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PaymentInfoId")
                        .HasColumnName("payment_info_id")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .HasColumnName("project_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Schema")
                        .HasColumnName("schema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int");

                    b.Property<bool>("Validated")
                        .HasColumnName("validated")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PaymentInfoId")
                        .IsUnique()
                        .HasFilter("[payment_info_id] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("user_projects");
                });

            modelBuilder.Entity("SiteCauldron.Models.Payment", b =>
                {
                    b.HasOne("SiteCauldron.Models.PricesCatalogEntry", "PaymentPrice")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentPriceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("SiteCauldron.Models.UserProject", b =>
                {
                    b.HasOne("SiteCauldron.Models.Payment", "PaymentInfo")
                        .WithOne("UserProject")
                        .HasForeignKey("SiteCauldron.Models.UserProject", "PaymentInfoId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("SiteCauldron.Models.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
