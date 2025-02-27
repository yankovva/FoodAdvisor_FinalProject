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
    [Migration("20241122125011_AddingChefsSpecialImageAndNameToRestaurant")]
    partial class AddingChefsSpecialImageAndNameToRestaurant
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
                        .HasDefaultValue(new DateTime(2024, 11, 22, 14, 50, 8, 435, DateTimeKind.Local).AddTicks(684))
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
                            Id = new Guid("6147b19b-5e6a-42e8-9850-ba151d4c3df8"),
                            Name = "Restaurant"
                        },
                        new
                        {
                            Id = new Guid("c21d9e5c-5a3d-440e-ba44-702d93251121"),
                            Name = "Cafe"
                        },
                        new
                        {
                            Id = new Guid("142e2129-8542-4b09-8336-56e6fe2a61f6"),
                            Name = "Bar & Dinner"
                        },
                        new
                        {
                            Id = new Guid("b2852bcb-acb9-4354-a805-05ece8cb9ad1"),
                            Name = "Fast Food"
                        },
                        new
                        {
                            Id = new Guid("df58c59e-20eb-44e9-a242-eb26afead207"),
                            Name = "Bakery"
                        },
                        new
                        {
                            Id = new Guid("f5d626e8-b6f4-45f3-a99c-190d49d67caf"),
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
                        .HasMaxLength(2083)
                        .HasColumnType("nvarchar(2083)");

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
                            Id = new Guid("a45c8c5f-283a-47b7-a8e4-43f80a1928e4"),
                            Name = "Breakfast"
                        },
                        new
                        {
                            Id = new Guid("d6b020cd-0bcb-4eca-8eee-f3af8c61b08b"),
                            Name = "Lunch"
                        },
                        new
                        {
                            Id = new Guid("33241044-63b4-4bfc-b221-96f89803de48"),
                            Name = "Dinner"
                        },
                        new
                        {
                            Id = new Guid("6e98ad6a-c161-465f-8db1-98112553ea9b"),
                            Name = "Dessert"
                        },
                        new
                        {
                            Id = new Guid("cdd38766-828f-41f4-a3f9-b95ae3d65d7f"),
                            Name = "Snack"
                        },
                        new
                        {
                            Id = new Guid("7c77d9dc-a92a-48b4-9ae3-32a5c3074e8e"),
                            Name = "Side dish"
                        },
                        new
                        {
                            Id = new Guid("47a60f2c-b432-4621-b4b0-47ca61967c92"),
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
