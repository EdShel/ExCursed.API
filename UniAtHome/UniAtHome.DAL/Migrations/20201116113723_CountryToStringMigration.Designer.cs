﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniAtHome.DAL;

namespace UniAtHome.DAL.Migrations
{
    [DbContext(typeof(UniAtHomeDbContext))]
    [Migration("20201116113723_CountryToStringMigration")]
    partial class CountryToStringMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "2AEFE1C5-C5F0-4399-8FB8-420813567554",
                            ConcurrencyStamp = "a0b6419c-3653-4f58-98c7-a85c859e12ba",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                            ConcurrencyStamp = "598000fd-78c4-4108-86a9-ef197ce85879",
                            Name = "UniversityAdmin",
                            NormalizedName = "UNIVERSITYADMIN"
                        },
                        new
                        {
                            Id = "828A3B02-77C0-45C1-8E97-6ED57711E577",
                            ConcurrencyStamp = "f341109e-eca8-48ad-82c5-b122413e429c",
                            Name = "Teacher",
                            NormalizedName = "TEACHER"
                        },
                        new
                        {
                            Id = "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                            ConcurrencyStamp = "bb2a12e6-ac16-4955-a80d-d10eb74f44cf",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "00CA41A9-C962-4230-937E-D5F54772C062",
                            RoleId = "2AEFE1C5-C5F0-4399-8FB8-420813567554"
                        },
                        new
                        {
                            UserId = "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                            RoleId = "99DA7670-5471-414F-834E-9B3A6B6C8F6F"
                        },
                        new
                        {
                            UserId = "E8D13331-62AB-463E-A283-6493B68A3622",
                            RoleId = "828A3B02-77C0-45C1-8E97-6ED57711E577"
                        },
                        new
                        {
                            UserId = "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                            RoleId = "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.CourseMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("CourseMembers");
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseMemberId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseMemberId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Added")
                        .HasColumnType("datetime2");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.Student", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UniversityId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            UserId = "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                            UniversityId = 1
                        });
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.StudentGroup", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("StudentGroups");
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.Teacher", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UniversityId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            UserId = "E8D13331-62AB-463E-A283-6493B68A3622",
                            UniversityId = 1
                        });
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.Timetable", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("GroupId", "LessonId");

                    b.HasIndex("LessonId");

                    b.ToTable("Timetables");
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Universities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Nauky Ave. 14, Kharkiv",
                            Country = "Ukraine",
                            Name = "Kharkiv National University of Radio Electronics",
                            ShortName = "Nure"
                        });
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.UniversityAdmin", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UniversityId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UniversityId");

                    b.ToTable("UniversityAdmins");

                    b.HasData(
                        new
                        {
                            UserId = "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                            UniversityId = 1
                        });
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.UniversityCreateRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubmitterFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubmitterLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniversityShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UniversityCreateRequests");
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

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
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "00CA41A9-C962-4230-937E-D5F54772C062",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e756c2c3-5d76-4446-9a9b-b9a33fa1520b",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "Adminovich",
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEPUhYVrIZtO+/oIBJuzszWKYc0x0saJAlMIuFEk6+zBVj+WO33Zbk0GWFsIsDp1Piw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "51178ab6-bd01-46bc-ba2e-0ebe4acd7f8d",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "526ac796-3452-4691-b436-f2de533a383b",
                            Email = "uadmin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Vladimir",
                            LastName = "Bream",
                            LockoutEnabled = false,
                            NormalizedEmail = "uadmin@gmail.com",
                            NormalizedUserName = "uadmin@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAELqjSPcIqxNutJec7O81smavdMOz0QehobXwA9SZLW4f+sxJ7bAyMwEGOidqKPn5vQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ea57cf58-bc7b-4f7c-92ac-a93d98ef9c2c",
                            TwoFactorEnabled = false,
                            UserName = "uadmin@gmail.com"
                        },
                        new
                        {
                            Id = "E8D13331-62AB-463E-A283-6493B68A3622",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0e8ad5cb-cb0f-48bb-a940-77031dec4bc5",
                            Email = "ihor.juice@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Ihor",
                            LastName = "Juice",
                            LockoutEnabled = false,
                            NormalizedEmail = "ihor.juice@gmail.com",
                            NormalizedUserName = "ihor.juice@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEEllom4tBAESRyu30P+mNUzE4v6w+2zAwH5CEkOCkhy+AM7Ui+baaafEux6tX/i1rg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "006eb7e6-ee3d-4018-998b-bb6f6435a1ae",
                            TwoFactorEnabled = false,
                            UserName = "ihor.juice@gmail.com"
                        },
                        new
                        {
                            Id = "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "44a9a43b-083e-4a77-9f4d-309a4fd5d9ba",
                            Email = "slava.ivanov@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Slava",
                            LastName = "Ivanov",
                            LockoutEnabled = false,
                            NormalizedEmail = "slava.ivanov@gmail.com",
                            NormalizedUserName = "slava.ivanov@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEKeqpJVRNeQ96v4JxJYo/xtl7+0/qTtOeNtkoV7Fl2/d2ljobcKtVxE/tuF6YJ5I2Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2f90ea2b-42af-4470-9c0d-e62d9b8b792a",
                            TwoFactorEnabled = false,
                            UserName = "slava.ivanov@gmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("UniAtHome.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("UniAtHome.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniAtHome.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("UniAtHome.DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.Course", b =>
                {
                    b.HasOne("UniAtHome.DAL.Entities.University", "University")
                        .WithMany("Courses")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.CourseMember", b =>
                {
                    b.HasOne("UniAtHome.DAL.Entities.Course", "Course")
                        .WithMany("CourseMembers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniAtHome.DAL.Entities.Teacher", "Teacher")
                        .WithMany("CourseMembers")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.Group", b =>
                {
                    b.HasOne("UniAtHome.DAL.Entities.CourseMember", "CourseMember")
                        .WithMany("Groups")
                        .HasForeignKey("CourseMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.Lesson", b =>
                {
                    b.HasOne("UniAtHome.DAL.Entities.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.RefreshToken", b =>
                {
                    b.HasOne("UniAtHome.DAL.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.Student", b =>
                {
                    b.HasOne("UniAtHome.DAL.Entities.University", "University")
                        .WithMany("Students")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniAtHome.DAL.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("UniAtHome.DAL.Entities.Student", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.StudentGroup", b =>
                {
                    b.HasOne("UniAtHome.DAL.Entities.Group", "Group")
                        .WithMany("StudentGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniAtHome.DAL.Entities.Student", "Student")
                        .WithMany("StudentGroups")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.Teacher", b =>
                {
                    b.HasOne("UniAtHome.DAL.Entities.University", "University")
                        .WithMany("Teachers")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniAtHome.DAL.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("UniAtHome.DAL.Entities.Teacher", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.Timetable", b =>
                {
                    b.HasOne("UniAtHome.DAL.Entities.Group", "Group")
                        .WithMany("Timetables")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniAtHome.DAL.Entities.Lesson", "Lesson")
                        .WithMany("Timetables")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("UniAtHome.DAL.Entities.UniversityAdmin", b =>
                {
                    b.HasOne("UniAtHome.DAL.Entities.University", "University")
                        .WithMany("UniversityAdmins")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniAtHome.DAL.Entities.User", "User")
                        .WithOne()
                        .HasForeignKey("UniAtHome.DAL.Entities.UniversityAdmin", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}