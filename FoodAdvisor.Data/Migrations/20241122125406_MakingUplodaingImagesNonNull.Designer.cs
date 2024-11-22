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
    [Migration("20241122125406_MakingUplodaingImagesNonNull")]
    partial class MakingUplodaingImagesNonNull
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

                    b.Property<string>("AboutMe")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Short descripton of the User.");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)")
                        .HasComment("User Country");

                    b.Property<DateTime>("Createdon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 11, 22, 14, 54, 4, 694, DateTimeKind.Local).AddTicks(7233))
                        .HasComment("Date of creation of the User.");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("First name of the User.");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Last name of the User.");

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

                    b.Property<string>("ProfilePricturePath")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("/assets/img/no-image-account.jfif")
                        .HasComment("Path for the Profile picture of the User.");

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
                            Id = new Guid("1106ab37-264e-4b39-8a15-4eaef9d22948"),
                            Name = "Restaurant"
                        },
                        new
                        {
                            Id = new Guid("300ab2f8-86dc-40ec-a853-785a7424d291"),
                            Name = "Cafe"
                        },
                        new
                        {
                            Id = new Guid("24ee65ee-8267-48a9-b2ff-419e320045fc"),
                            Name = "Bar & Dinner"
                        },
                        new
                        {
                            Id = new Guid("fb4fa57b-9a21-4c5c-a95f-a83aeb736c24"),
                            Name = "Fast Food"
                        },
                        new
                        {
                            Id = new Guid("e8b65baf-9871-4781-bf3e-dcf9388d2d89"),
                            Name = "Bakery"
                        },
                        new
                        {
                            Id = new Guid("babb3713-13a1-46c2-a677-5b58ac0959c1"),
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Name of the Recepie.");

                    b.Property<int>("NumberOfServing")
                        .HasColumnType("int")
                        .HasComment("Number of servings for the Recepie");

                    b.Property<string>("Products")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("Needed products for the Recepie.");

                    b.Property<Guid>("PublisherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecepieCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RecepieDificultyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.HasIndex("RecepieCategoryId");

                    b.HasIndex("RecepieDificultyId");

                    b.ToTable("Recepies");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.RecepieCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The idemtifier of the Recepie category.");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("The name of the Recepie category.");

                    b.HasKey("Id");

                    b.ToTable("RecepiesCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8007d0d0-20fe-443a-b2e8-736751044fbf"),
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = new Guid("2de7d11a-514b-496d-acb9-4c2628cc88bf"),
                            Name = "Lunch"
                        },
                        new
                        {
                            Id = new Guid("787d7046-6f17-468c-8006-c7cf7b4bfcc0"),
                            Name = "Dinner"
                        },
                        new
                        {
                            Id = new Guid("1727c611-8413-46f8-8edd-e18af9b0eee4"),
                            Name = "Dessert"
                        },
                        new
                        {
                            Id = new Guid("b0ade557-602d-4be4-8440-3dd4078e7e37"),
                            Name = "Snack"
                        },
                        new
                        {
                            Id = new Guid("ae70a0ee-f99f-41fd-8cbf-ea8161c1e1a2"),
                            Name = "Side dish"
                        },
                        new
                        {
                            Id = new Guid("f56357ac-b0a2-4761-9fd8-70b4effd7e9d"),
                            Name = "Starter"
                        });
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

            modelBuilder.Entity("FoodAdvisor.Data.Models.RecepieDificulty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("The idemtifier of the Recepie Dificulty.");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DificultyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("The name of the Recepie dificulty level.");

                    b.HasKey("Id");

                    b.ToTable("RecepiesDificulties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DificultyName = "Easy"
                        },
                        new
                        {
                            Id = 2,
                            DificultyName = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            DificultyName = "Hard"
                        },
                        new
                        {
                            Id = 4,
                            DificultyName = "Expert"
                        });
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

                    b.Property<string>("AtmosphereDescription")
                        .IsRequired()
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)")
                        .HasComment("The Atmosphere Description of the Restaurant.");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The Category Id.");

                    b.Property<string>("ChefsSpecial")
                        .IsRequired()
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)")
                        .HasComment("The Chefs special dish of the Restaurant.");

                    b.Property<string>("ChefsSpecialImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("An Image Path of the Chefs special dish of the  Restaurant.");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The City Id.");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)")
                        .HasComment("The Description of the Restaurant.");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("An Image Path of the Restaurant.");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Shows wether the restaurant is deleted or not");

                    b.Property<string>("MenuDescription")
                        .IsRequired()
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)")
                        .HasComment("The Menu Description of the Restaurant.");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("The Name of the Restaurant.");

                    b.Property<string>("PricaRange")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("$")
                        .HasComment("Shows the price range of the restaurant.");

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

            modelBuilder.Entity("FoodAdvisor.ViewModels.ApplicationRole", b =>
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

                    b.HasOne("FoodAdvisor.Data.Models.RecepieCategory", "RecepieCategory")
                        .WithMany("Recepies")
                        .HasForeignKey("RecepieCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAdvisor.Data.Models.RecepieDificulty", "RecepieDificulty")
                        .WithMany("Recepies")
                        .HasForeignKey("RecepieDificultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");

                    b.Navigation("RecepieCategory");

                    b.Navigation("RecepieDificulty");
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
                    b.HasOne("FoodAdvisor.ViewModels.ApplicationRole", null)
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
                    b.HasOne("FoodAdvisor.ViewModels.ApplicationRole", null)
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

            modelBuilder.Entity("FoodAdvisor.Data.Models.RecepieCategory", b =>
                {
                    b.Navigation("Recepies");
                });

            modelBuilder.Entity("FoodAdvisor.Data.Models.RecepieDificulty", b =>
                {
                    b.Navigation("Recepies");
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
