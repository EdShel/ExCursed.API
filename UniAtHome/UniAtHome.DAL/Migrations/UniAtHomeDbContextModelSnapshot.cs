﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniAtHome.DAL;

namespace UniAtHome.DAL.Migrations
{
    [DbContext(typeof(UniAtHomeDbContext))]
    partial class UniAtHomeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            ConcurrencyStamp = "ce02f73b-7e5e-4bf8-b70a-f13afd494d86",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "99DA7670-5471-414F-834E-9B3A6B6C8F6F",
                            ConcurrencyStamp = "5dc11c9d-13ae-4332-a228-c3fb61ecb8a0",
                            Name = "UniversityAdmin",
                            NormalizedName = "UNIVERSITYADMIN"
                        },
                        new
                        {
                            Id = "828A3B02-77C0-45C1-8E97-6ED57711E577",
                            ConcurrencyStamp = "944b71b2-a316-411f-bbe3-e99171ab15c8",
                            Name = "Teacher",
                            NormalizedName = "TEACHER"
                        },
                        new
                        {
                            Id = "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C",
                            ConcurrencyStamp = "c92dcab9-cfd7-4055-9c3a-3432a53198c9",
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Universities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "NURE"
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

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Submitted")
                        .HasColumnType("datetime2");

                    b.Property<string>("SubmitterFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubmitterLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniversityName")
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
                            ConcurrencyStamp = "50ac185a-ea76-458a-941b-49ffd20cebb1",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            LastName = "Adminovich",
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEEFEPVW1yCuZQY4pYAi3rwTIWFroK255Kd8AX+kgnnXAg70JMet6DfVdszS+qS8tfA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1374e5fe-1910-4102-8408-c54479ade4ef",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6f372340-d1b1-4d17-a1b0-0359641961bf",
                            Email = "uadmin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Vladimir",
                            LastName = "Bream",
                            LockoutEnabled = false,
                            NormalizedEmail = "uadmin@gmail.com",
                            NormalizedUserName = "uadmin@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEMWifViQRyszyoave0rP8ASP7Iop5h9XvCDqIQv5o6rt0rG3WHOU5wTt86sd0jlQ7Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "de31b772-a574-4fe8-8258-d39c8c34d3e8",
                            TwoFactorEnabled = false,
                            UserName = "uadmin@gmail.com"
                        },
                        new
                        {
                            Id = "E8D13331-62AB-463E-A283-6493B68A3622",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "921c6b13-cb7f-435a-9446-2493397e433e",
                            Email = "ihor.juice@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Ihor",
                            LastName = "Juice",
                            LockoutEnabled = false,
                            NormalizedEmail = "ihor.juice@gmail.com",
                            NormalizedUserName = "ihor.juice@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAEE0mDVXE48XvTHz9gtyM3eDG3TiOvrYc9rDG8iEWyK1crjGB+QFsGR4sWmh5jFta0A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3d4507db-dde5-40fd-a88d-4fa2132fbe30",
                            TwoFactorEnabled = false,
                            UserName = "ihor.juice@gmail.com"
                        },
                        new
                        {
                            Id = "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "37c8fa30-95af-4b37-b6b5-f27257547f7e",
                            Email = "slava.ivanov@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Slava",
                            LastName = "Ivanov",
                            LockoutEnabled = false,
                            NormalizedEmail = "slava.ivanov@gmail.com",
                            NormalizedUserName = "slava.ivanov@gmail.com",
                            PasswordHash = "AQAAAAEAACcQAAAAECDHlx4npTJVJzfCjGGoUHs6MpOad2hy0Hn9FQa8rdNx5ksh15J8zuBn+wHd88cAlQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "923928b1-a8b4-4b37-aa2a-eeebdacc263b",
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
