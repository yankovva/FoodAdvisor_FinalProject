﻿// <auto-generated />
using System;
using FoodAdvisor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodAdvisor.Data.Migrations
{
    [DbContext(typeof(FoodAdvisorDbContext))]
    [Migration("20241111142411_AddingRecepiesComments")]
    partial class AddingRecepiesComments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodAdvisor.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The Unique Identifier of the Category.");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("The Name of the Category.");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0469830e-21fb-4e3e-96e2-a60dc8ba54e9"),
                            Name = "Restaurant"
                        },
                        new
                        {
                            Id = new Guid("85df763a-3a28-40d2-ad7b-90df4588dd11"),
                            Name = "Cafe"
                        },
                        new
                        {
                            Id = new Guid("3e36e78d-474b-4ebf-b343-3ae799e6e68b"),
                            Name = "Bar & Dinner"
                        },
                        new
                        {
                            Id = new Guid("c4b544c8-2a59-4c44-82c8-c352c9c84b9e"),
                            Name = "Fast Food"
                        },
                        new
                        {
                            Id = new Guid("27d45d05-f19c-44b9-9bcb-11b24fe0b089"),
                            Name = "Bakery"
                        },
                        new
                        {
                            Id = new Guid("ced3a94a-69d0-47b9-ba4a-f1c104725b28"),
                            Name = "Bistro"
                        });
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Unique Identifier for the city.");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)")
                        .HasComment("The name of the city.");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eebb18ac-5a0f-4746-b4be-0a91758248a9"),
                            Name = "Plovdiv"
                        },
                        new
                        {
                            Id = new Guid("9bdf20a3-9b13-4a4d-80bc-cf79869be15b"),
                            Name = "Sofia"
                        },
                        new
                        {
                            Id = new Guid("47fec972-f573-4bf8-bc00-468d8869f9f0"),
                            Name = "Varna"
                        },
                        new
                        {
                            Id = new Guid("d4e65226-b6ff-4220-99fa-56d03b8fd9cb"),
                            Name = "Burgas"
                        },
                        new
                        {
                            Id = new Guid("e5ce230c-eaf4-40d4-bf60-7e28e8b11775"),
                            Name = "Stara Zagora"
                        },
                        new
                        {
                            Id = new Guid("99efb2c7-9875-4ad1-a3b6-f9944346b511"),
                            Name = "Ruse"
                        });
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The unique identifier of the manager.");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasComment("Address of the manager.");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WorkPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Work phone number of the manager.");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.Recepie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CookingTime")
                        .HasColumnType("int")
                        .HasComment("Cooking time of the Recepie.");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date of creation of the Recepie.");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasComment("Description of the Recepie.");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(2083)
                        .HasColumnType("nvarchar(2083)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Name of the Recepie.");

                    b.Property<Guid>("PublisherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Recepies");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.RecepieComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identifier of the Recepie.");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date of creation of the Comment.");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("The message of the Recepie.");

                    b.Property<Guid>("RecepieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RecepieId");

                    b.HasIndex("UserId");

                    b.ToTable("RecepiesComments");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.Restaurant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The Unique Identifier of the Restaurant.");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("nvarchar(85)")
                        .HasComment("The Address of the Restaurant.");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The Category Id.");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The City Id.");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("The Description of the Restaurant.");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(2083)
                        .HasColumnType("nvarchar(2083)")
                        .HasComment("An Image Url of the Restaurant.");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Shows wether the restaurant is deleted or not");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("The Name of the Restaurant.");

                    b.Property<Guid>("PublisherId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The Publisher Id.");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CityId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.RestaurantComment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identifier of the Comment.");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasComment("Date of creation of the Comment.");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("The message of the Comment.");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("RestaurantsComments");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.UserRecepie", b =>
                {
                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identifier of the ApplicationUser");

                    b.Property<Guid>("RecepieId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identifier of the Restaurant");

                    b.HasKey("ApplicationUserId", "RecepieId");

                    b.HasIndex("RecepieId");

                    b.ToTable("UsersRecepies");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.UserRestaurant", b =>
                {
                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identifier of the ApplicationUser");

                    b.Property<Guid>("RestaurantId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Identifier of the Recepie");

                    b.HasKey("ApplicationUserId", "RestaurantId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("UsersRestaurants");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.Manager", b =>
                {
                    b.HasOne("FoodAdvisor.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.Recepie", b =>
                {
                    b.HasOne("FoodAdvisor.Data.Models.ApplicationUser", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.RecepieComment", b =>
                {
                    b.HasOne("FoodAdvisor.Data.Models.Recepie", "Recepie")
                        .WithMany("RecepieComments")
                        .HasForeignKey("RecepieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAdvisor.Data.Models.ApplicationUser", "User")
                        .WithMany("RecepiesComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recepie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.Restaurant", b =>
                {
                    b.HasOne("FoodAdvisor.Data.Models.Category", "Category")
                        .WithMany("Restaurants")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAdvisor.Data.Models.City", "City")
                        .WithMany("Restaurants")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAdvisor.Data.Models.ApplicationUser", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("City");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.RestaurantComment", b =>
                {
                    b.HasOne("FoodAdvisor.Data.Models.Restaurant", "Restaurant")
                        .WithMany("RestaurantsComments")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAdvisor.Data.Models.ApplicationUser", "User")
                        .WithMany("RestaurantsComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.UserRecepie", b =>
                {
                    b.HasOne("FoodAdvisor.Data.Models.ApplicationUser", "User")
                        .WithMany("Recepies")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAdvisor.Data.Models.Recepie", "Recepie")
                        .WithMany("UsersRecepies")
                        .HasForeignKey("RecepieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recepie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.UserRestaurant", b =>
                {
                    b.HasOne("FoodAdvisor.Data.Models.ApplicationUser", "User")
                        .WithMany("Restaurants")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAdvisor.Data.Models.Restaurant", "Restaurant")
                        .WithMany("UserRestaurants")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("FoodAdvisor.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("FoodAdvisor.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAdvisor.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("FoodAdvisor.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Recepies");

                    b.Navigation("RecepiesComments");

                    b.Navigation("Restaurants");

                    b.Navigation("RestaurantsComments");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.Category", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.City", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.Recepie", b =>
                {
                    b.Navigation("RecepieComments");

                    b.Navigation("UsersRecepies");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.Restaurant", b =>
                {
                    b.Navigation("RestaurantsComments");

                    b.Navigation("UserRestaurants");
                });
#pragma warning restore 612, 618
        }
    }
}