﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetitionManagementSystem.Connection;

#nullable disable

namespace PetitionManagementSystem.Migrations
{
    [DbContext(typeof(PetitionManagementDBContext))]
    [Migration("20240326150355_initialfr")]
    partial class initialfr
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PetitionManagementSystem.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Adminmobilenumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AdminId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("PetitionManagementSystem.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasColumnType("longtext");

                    b.HasKey("CategoryId");

                    b.HasIndex("AdminId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("PetitionManagementSystem.Models.PentitionPetitionHandler", b =>
                {
                    b.Property<int>("PentitionPetitionHandlerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PetitionHandlerId")
                        .HasColumnType("int");

                    b.Property<int>("PetitionId")
                        .HasColumnType("int");

                    b.HasKey("PentitionPetitionHandlerId");

                    b.HasIndex("PetitionHandlerId");

                    b.HasIndex("PetitionId");

                    b.ToTable("PentitionPetitionHandler");
                });

            modelBuilder.Entity("PetitionManagementSystem.Models.Petition", b =>
                {
                    b.Property<int>("PetitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<long>("AadharNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PetitionDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("StatusType")
                        .HasColumnType("longtext");

                    b.Property<string>("TalukLocation")
                        .HasColumnType("longtext");

                    b.Property<string>("UploadDocumentname")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PetitionId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Petition");
                });

            modelBuilder.Entity("PetitionManagementSystem.Models.PetitionHandler", b =>
                {
                    b.Property<int>("PetitionHandlerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("longtext");

                    b.Property<int>("OfficialId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TalukLocation")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("PetitionHandlerId");

                    b.HasIndex("AdminId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PetitionHandlers");
                });

            modelBuilder.Entity("PetitionManagementSystem.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.Property<string>("city")
                        .HasColumnType("longtext");

                    b.Property<string>("state")
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PetitionManagementSystem.Models.Category", b =>
                {
                    b.HasOne("PetitionManagementSystem.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("PetitionManagementSystem.Models.PentitionPetitionHandler", b =>
                {
                    b.HasOne("PetitionManagementSystem.Models.PetitionHandler", "PetitionHandler")
                        .WithMany("Handler")
                        .HasForeignKey("PetitionHandlerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetitionManagementSystem.Models.Petition", "Petition")
                        .WithMany("Handler")
                        .HasForeignKey("PetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Petition");

                    b.Navigation("PetitionHandler");
                });

            modelBuilder.Entity("PetitionManagementSystem.Models.Petition", b =>
                {
                    b.HasOne("PetitionManagementSystem.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetitionManagementSystem.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PetitionManagementSystem.Models.PetitionHandler", b =>
                {
                    b.HasOne("PetitionManagementSystem.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetitionManagementSystem.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PetitionManagementSystem.Models.Petition", b =>
                {
                    b.Navigation("Handler");
                });

            modelBuilder.Entity("PetitionManagementSystem.Models.PetitionHandler", b =>
                {
                    b.Navigation("Handler");
                });
#pragma warning restore 612, 618
        }
    }
}
