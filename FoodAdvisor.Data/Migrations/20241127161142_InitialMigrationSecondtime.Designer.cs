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
    [Migration("20241127161142_InitialMigrationSecondtime")]
    partial class InitialMigrationSecondtime
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
                        .HasDefaultValue(new DateTime(2024, 11, 27, 18, 11, 40, 150, DateTimeKind.Local).AddTicks(1892))
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
                        .HasDefaultValue("assets/img/no-pfp.png")
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
                            Id = new Guid("3aecc994-908a-4eb6-9b07-0426bfdca82c"),
                            Name = "Restaurant"
                        },
                        new
                        {
                            Id = new Guid("0958bc87-5971-4637-b8dc-526eca676ca3"),
                            Name = "Cafe"
                        },
                        new
                        {
                            Id = new Guid("1dbfde57-e106-47ad-9308-796905286284"),
                            Name = "Bar & Dinner"
                        },
                        new
                        {
                            Id = new Guid("5be98fc1-4b6c-4914-a8b0-495fe59a0aac"),
                            Name = "Fast Food"
                        },
                        new
                        {
                            Id = new Guid("dd9a1047-8d6c-43b4-b5e3-618feea36d2c"),
                            Name = "Bakery"
                        },
                        new
                        {
                            Id = new Guid("1c339593-b820-4f9f-af8a-63dd825e7ba8"),
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

            modelBuilder.Entity("FoodAdvisor.Data.Models.Comment", b =>
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

                    b.Property<Guid?>("RecepieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RestaurantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RecepieId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
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
                            Id = new Guid("34623df8-e251-4379-85bf-826c1285be72"),
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = new Guid("1cfbda7e-3876-4929-84f4-4a558ba28a26"),
                            Name = "Lunch"
                        },
                        new
                        {
                            Id = new Guid("48fd8143-018e-49b1-bf34-61b763e83aa6"),
                            Name = "Dinner"
                        },
                        new
                        {
                            Id = new Guid("25776863-a10a-4b05-90a5-7c2b5c12083e"),
                            Name = "Dessert"
                        },
                        new
                        {
                            Id = new Guid("3dd42454-f617-4215-a385-55460dbe34f8"),
                            Name = "Snack"
                        },
                        new
                        {
                            Id = new Guid("8efe17a0-f1dd-4503-9884-c238d6a94139"),
                            Name = "Side dish"
                        },
                        new
                        {
                            Id = new Guid("7731ee90-1ebf-4ce1-a2e1-e5c7dd73c24b"),
                            Name = "Starter"
                        });
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
                            Id = new Guid("09211d2b-eefa-43b2-a1ec-d9c7b130e8fd"),
                            Name = "Mediteranean"
                        },
                        new
                        {
                            Id = new Guid("e76666a6-9f96-4514-825d-29ddc11d3168"),
                            Name = "Chinease"
                        },
                        new
                        {
                            Id = new Guid("22ea26c3-d86e-40f2-acb7-6e3df34d1188"),
                            Name = "Italian"
                        },
                        new
                        {
                            Id = new Guid("aaafce16-3805-4b41-871f-37720f897168"),
                            Name = "Bulgarian"
                        },
                        new
                        {
                            Id = new Guid("ea8282cf-c315-4859-bba6-9884fd7320d1"),
                            Name = "Mexican"
                        },
                        new
                        {
                            Id = new Guid("4427cbdf-fdcd-4d6d-a3e2-8f3680a069b1"),
                            Name = "Only drinks"
                        },
                        new
                        {
                            Id = new Guid("35480bc6-20fe-43be-83bd-d3cf6fb988c7"),
                            Name = "Japanese"
                        },
                        new
                        {
                            Id = new Guid("4c41900f-54d6-4719-93ae-7bea7bf82c5f"),
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

            modelBuilder.Entity("FoodAdvisor.Data.Models.Comment", b =>
                {
                    b.HasOne("FoodAdvisor.Data.Models.Recepie", "Recepie")
                        .WithMany("RecepieComments")
                        .HasForeignKey("RecepieId");

                    b.HasOne("FoodAdvisor.Data.Models.Restaurant", "Restaurant")
                        .WithMany("RestaurantsComments")
                        .HasForeignKey("RestaurantId");

                    b.HasOne("FoodAdvisor.Data.Models.ApplicationUser", "User")
                        .WithMany("UsersComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recepie");

                    b.Navigation("Restaurant");

                    b.Navigation("User");
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
                        .WithMany("AddedRecepies")
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
                        .WithMany("AddedRestaurants")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("City");

                    b.Navigation("Cuisine");

                    b.Navigation("Publisher");
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
                    b.Navigation("AddedRecepies");

                    b.Navigation("AddedRestaurants");

                    b.Navigation("Recepies");

                    b.Navigation("Restaurants");

                    b.Navigation("UsersComments");
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
