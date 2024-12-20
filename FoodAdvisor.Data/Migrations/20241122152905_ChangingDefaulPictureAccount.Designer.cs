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
    [Migration("20241122152905_ChangingDefaulPictureAccount")]
    partial class ChangingDefaulPictureAccount
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
                        .HasDefaultValue(new DateTime(2024, 11, 22, 17, 29, 3, 228, DateTimeKind.Local).AddTicks(6034))
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
                        .HasDefaultValue("/assets/img/no-pfp.png")
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
                            Id = new Guid("55a54e42-0215-4ff1-b320-333ddc164d0f"),
                            Name = "Restaurant"
                        },
                        new
                        {
                            Id = new Guid("086f6c2c-e726-4753-83ae-9ce493607dfe"),
                            Name = "Cafe"
                        },
                        new
                        {
                            Id = new Guid("eaf354da-3f24-448b-bc63-44c1015bd7a1"),
                            Name = "Bar & Dinner"
                        },
                        new
                        {
                            Id = new Guid("bf94d541-c0da-4c45-a8bb-2dab58b5dbc1"),
                            Name = "Fast Food"
                        },
                        new
                        {
                            Id = new Guid("c4bbe80b-04ae-4fb8-a766-d88487055ba5"),
                            Name = "Bakery"
                        },
                        new
                        {
                            Id = new Guid("8e8acbb0-161b-43a5-9a62-af1e17c8a2e9"),
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
                            Id = new Guid("0123fef5-d679-4bac-84a0-69442117a920"),
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = new Guid("bd91cd58-02d6-4c41-9f3b-b3e6a769ec12"),
                            Name = "Lunch"
                        },
                        new
                        {
                            Id = new Guid("c467002f-aaad-49e7-a1cf-17f99bd22482"),
                            Name = "Dinner"
                        },
                        new
                        {
                            Id = new Guid("7d8bd8ed-c42e-4c2d-b866-c7677ca7368b"),
                            Name = "Dessert"
                        },
                        new
                        {
                            Id = new Guid("f5e4e699-8fe2-4e5b-9338-8faf1965780c"),
                            Name = "Snack"
                        },
                        new
                        {
                            Id = new Guid("aae9877b-8d34-43f4-9fdb-4e9bb90d0a35"),
                            Name = "Side dish"
                        },
                        new
                        {
                            Id = new Guid("de21ad46-c3b4-4def-b3df-8c1efbe034cc"),
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

                    b.Property<Guid>("CuisineId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("The Cuisine Id.");

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

                    b.HasIndex("CuisineId");

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

            modelBuilder.Entity("FoodAdvisor.Data.Models.RestaurantCuisine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("The name of the Cuisine type.");

                    b.HasKey("Id");

                    b.ToTable("Cuisines");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8fa7149c-7805-47d5-b5bc-12c1e7704bd4"),
                            Name = "Mediteranean"
                        },
                        new
                        {
                            Id = new Guid("0ccbd527-0248-49d4-aeb2-abd07bca9a41"),
                            Name = "Chinease"
                        },
                        new
                        {
                            Id = new Guid("4d1cff44-c09f-4a04-8c3c-e98d2c5adc7c"),
                            Name = "Italian"
                        },
                        new
                        {
                            Id = new Guid("13682688-2eeb-4c04-bdef-84cc500498c3"),
                            Name = "Bulgarian"
                        },
                        new
                        {
                            Id = new Guid("eaf3bc8a-8987-480d-9e98-69585ca01a9c"),
                            Name = "Mexican"
                        },
                        new
                        {
                            Id = new Guid("1b14b3ba-5dea-4738-8a20-0062431898bd"),
                            Name = "Only drinks"
                        },
                        new
                        {
                            Id = new Guid("c9bb4f98-f4f0-450c-8684-475c101d9aa7"),
                            Name = "Japanese"
                        },
                        new
                        {
                            Id = new Guid("afc5adb1-4201-4e21-ada0-c05beec8860f"),
                            Name = "French"
                        });
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

                    b.HasOne("FoodAdvisor.Data.Models.RestaurantCuisine", "Cuisine")
                        .WithMany("Restaurants")
                        .HasForeignKey("CuisineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodAdvisor.Data.Models.ApplicationUser", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("City");

                    b.Navigation("Cuisine");

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

            modelBuilder.Entity("FoodAdvisor.Data.Models.RestaurantCuisine", b =>
                {
                    b.Navigation("Restaurants");
                });
#pragma warning restore 612, 618
        }
    }
}
