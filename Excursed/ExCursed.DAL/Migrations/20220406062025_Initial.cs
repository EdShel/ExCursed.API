using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExCursed.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    ShortName = table.Column<string>(maxLength: 20, nullable: true),
                    Address = table.Column<string>(maxLength: 400, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniversityCreateRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UniversityName = table.Column<string>(nullable: false),
                    UniversityShortName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: false),
                    SubmitterFirstName = table.Column<string>(nullable: false),
                    SubmitterLastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityCreateRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZoomMeetings",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    LessonId = table.Column<int>(nullable: false),
                    ZoomId = table.Column<long>(nullable: false),
                    JoinUrl = table.Column<string>(nullable: true),
                    StartUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoomMeetings", x => new { x.GroupId, x.LessonId });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    Token = table.Column<string>(maxLength: 100, nullable: false),
                    ExpirationDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZoomUsers",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoomUsers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ZoomUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Added = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: true),
                    UniversityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UniversityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Students_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UniversityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Teachers_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniversityAdmins",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UniversityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityAdmins", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UniversityAdmins_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UniversityAdmins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Added = table.Column<DateTimeOffset>(nullable: false),
                    Modified = table.Column<DateTimeOffset>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherId = table.Column<string>(nullable: true),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMembers_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseMembers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DurationMinutes = table.Column<int>(nullable: false),
                    ShuffleQuestions = table.Column<bool>(nullable: false),
                    ShuffleVariants = table.Column<bool>(nullable: false),
                    AttemptsAllowed = table.Column<int>(nullable: false),
                    MaxMark = table.Column<float>(nullable: false),
                    LessonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tests_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tests_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    CourseMemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_CourseMembers_CourseMemberId",
                        column: x => x.CourseMemberId,
                        principalTable: "CourseMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestAttempts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: true),
                    TestId = table.Column<int>(nullable: false),
                    BeginTime = table.Column<DateTimeOffset>(nullable: false),
                    EndTime = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestAttempts_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestAttempts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TestId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Checkbox = table.Column<bool>(nullable: false),
                    Weight = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestQuestions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentGroups",
                columns: table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroups", x => new { x.StudentId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_StudentGroups_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentGroups_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Timetables",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    LessonId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    ZoomMeetingGroupId = table.Column<int>(nullable: true),
                    ZoomMeetingLessonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timetables", x => new { x.GroupId, x.LessonId });
                    table.ForeignKey(
                        name: "FK_Timetables_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timetables_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Timetables_ZoomMeetings_ZoomMeetingGroupId_ZoomMeetingLessonId",
                        columns: x => new { x.ZoomMeetingGroupId, x.ZoomMeetingLessonId },
                        principalTable: "ZoomMeetings",
                        principalColumns: new[] { "GroupId", "LessonId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestAnswerVariants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    IsCorrect = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAnswerVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestAnswerVariants_TestQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "TestQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TestId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    LessonId = table.Column<int>(nullable: false),
                    BeginTime = table.Column<DateTimeOffset>(nullable: false),
                    EndTime = table.Column<DateTimeOffset>(nullable: false),
                    TimetableGroupId = table.Column<int>(nullable: true),
                    TimetableLessonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestSchedules_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestSchedules_Timetables_TimetableGroupId_TimetableLessonId",
                        columns: x => new { x.TimetableGroupId, x.TimetableLessonId },
                        principalTable: "Timetables",
                        principalColumns: new[] { "GroupId", "LessonId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestAnsweredQuestions",
                columns: table => new
                {
                    AttemptId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    IsCorrect = table.Column<bool>(nullable: false),
                    AnswerVariantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestAnsweredQuestions", x => new { x.AttemptId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_TestAnsweredQuestions_TestAnswerVariants_AnswerVariantId",
                        column: x => x.AnswerVariantId,
                        principalTable: "TestAnswerVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TestAnsweredQuestions_TestAttempts_AttemptId",
                        column: x => x.AttemptId,
                        principalTable: "TestAttempts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TestAnsweredQuestions_TestQuestions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "TestQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2AEFE1C5-C5F0-4399-8FB8-420813567554", "abd8293c-5007-4749-b101-a7ca10d91e9c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "99DA7670-5471-414F-834E-9B3A6B6C8F6F", "872f98b6-a513-4c87-9cb7-31a0b56d542f", "UniversityAdmin", "UNIVERSITYADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "828A3B02-77C0-45C1-8E97-6ED57711E577", "8c95341d-3507-4021-a131-e58252fa48be", "Teacher", "TEACHER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C", "be32e3f3-363e-4dc0-a4d0-e66f7193b70b", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "00CA41A9-C962-4230-937E-D5F54772C062", 0, "a26a1be5-a103-4e8b-8d13-a6a23e585d0e", "admin@gmail.com", false, "Admin", "Adminovich", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEOf+3JrEIi60CGWFiLTGSsP1rmxPRxn+tbuQIJVyGxO7ZAnr+FBAg0uK2Wcm4PEnqw==", null, false, "de5eca2f-8f7a-4061-8273-ba2c17cb1840", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09", 0, "da0c839e-7ce5-475a-8bf2-60b8edfa6ae5", "uadmin@gmail.com", false, "Vladimir", "Bream", false, null, "UADMIN@GMAIL.COM", "UADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEPctDLxgQJ7bNQcMg91oQIXBSm8YxJOrUFvTGNQGYDdgja8pV5RFD8kSjnsHDnfgow==", null, false, "c87bee6c-df8e-490a-8f00-49ace9cb68be", false, "uadmin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "E8D13331-62AB-463E-A283-6493B68A3622", 0, "8317d3ef-7641-4c38-9c02-c6ba74839e9e", "ihor.juice@gmail.com", false, "Ihor", "Juice", false, null, "IHOR.JUICE@GMAIL.COM", "IHOR.JUICE@GMAIL.COM", "AQAAAAEAACcQAAAAEMQLj28p+8n5q5R1FTb5a+yZSBs8Q8DADKwATs09o/pBVzYlAXFnvxx3J88ifqvi1A==", null, false, "0aac2288-ea39-473f-9647-765487e5cd05", false, "ihor.juice@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B", 0, "c382e459-25ac-4406-a8f9-df41b31b7dc7", "slava.ivanov@gmail.com", false, "Slava", "Ivanov", false, null, "SLAVA.IVANOV@GMAIL.COM", "SLAVA.IVANOV@GMAIL.COM", "AQAAAAEAACcQAAAAEDYgYTRwgHeumuDBLv/0LPO7Sa2V+MW2lEOj0BfShs7AvCM8MwxSwdiIIUJXz59TMg==", null, false, "0483845e-7bbe-4a84-86b2-c516a68ccba1", false, "slava.ivanov@gmail.com" });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Address", "Country", "Name", "ShortName" },
                values: new object[] { 1, "Nauky Ave. 14, Kharkiv", "Ukraine", "Kharkiv National University of Radio Electronics", "Nure" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "00CA41A9-C962-4230-937E-D5F54772C062", "2AEFE1C5-C5F0-4399-8FB8-420813567554" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09", "99DA7670-5471-414F-834E-9B3A6B6C8F6F" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "E8D13331-62AB-463E-A283-6493B68A3622", "828A3B02-77C0-45C1-8E97-6ED57711E577" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B", "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Added", "Description", "ImagePath", "Modified", "Name", "UniversityId" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Teaching how to write clean code", null, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Code analysis and refactoring", 1 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "UserId", "UniversityId" },
                values: new object[] { "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B", 1 });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "UserId", "UniversityId" },
                values: new object[] { "E8D13331-62AB-463E-A283-6493B68A3622", 1 });

            migrationBuilder.InsertData(
                table: "UniversityAdmins",
                columns: new[] { "UserId", "UniversityId" },
                values: new object[] { "BFCC8BAB-AD20-4F70-9CD9-D2003FAE6F09", 1 });

            migrationBuilder.InsertData(
                table: "CourseMembers",
                columns: new[] { "Id", "CourseId", "TeacherId" },
                values: new object[] { 1, 1, "E8D13331-62AB-463E-A283-6493B68A3622" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Added", "CourseId", "Description", "Modified", "Title" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Java does not rule, however we have to pretend it does", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Learning Java" });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "CourseMemberId", "Name" },
                values: new object[] { 1, 1, "SE-18-6" });

            migrationBuilder.InsertData(
                table: "StudentGroups",
                columns: new[] { "StudentId", "GroupId" },
                values: new object[] { "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseMembers_CourseId",
                table: "CourseMembers",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMembers_TeacherId",
                table: "CourseMembers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UniversityId",
                table: "Courses",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_CourseMemberId",
                table: "Group",
                column: "CourseMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroups_GroupId",
                table: "StudentGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UniversityId",
                table: "Students",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UniversityId",
                table: "Teachers",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAnsweredQuestions_AnswerVariantId",
                table: "TestAnsweredQuestions",
                column: "AnswerVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAnsweredQuestions_QuestionId",
                table: "TestAnsweredQuestions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAnswerVariants_QuestionId",
                table: "TestAnswerVariants",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAttempts_TestId",
                table: "TestAttempts",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestAttempts_UserId",
                table: "TestAttempts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_TestId",
                table: "TestQuestions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_CourseId",
                table: "Tests",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_LessonId",
                table: "Tests",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSchedules_TestId",
                table: "TestSchedules",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSchedules_TimetableGroupId_TimetableLessonId",
                table: "TestSchedules",
                columns: new[] { "TimetableGroupId", "TimetableLessonId" });

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_LessonId",
                table: "Timetables",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_ZoomMeetingGroupId_ZoomMeetingLessonId",
                table: "Timetables",
                columns: new[] { "ZoomMeetingGroupId", "ZoomMeetingLessonId" });

            migrationBuilder.CreateIndex(
                name: "IX_UniversityAdmins_UniversityId",
                table: "UniversityAdmins",
                column: "UniversityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "StudentGroups");

            migrationBuilder.DropTable(
                name: "TestAnsweredQuestions");

            migrationBuilder.DropTable(
                name: "TestSchedules");

            migrationBuilder.DropTable(
                name: "UniversityAdmins");

            migrationBuilder.DropTable(
                name: "UniversityCreateRequests");

            migrationBuilder.DropTable(
                name: "ZoomUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "TestAnswerVariants");

            migrationBuilder.DropTable(
                name: "TestAttempts");

            migrationBuilder.DropTable(
                name: "Timetables");

            migrationBuilder.DropTable(
                name: "TestQuestions");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "ZoomMeetings");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "CourseMembers");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
