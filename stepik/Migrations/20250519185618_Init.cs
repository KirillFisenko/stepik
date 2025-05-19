using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace stepik.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    summary = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    photo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "lessons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    epic_count = table.Column<int>(type: "int", nullable: false),
                    abuse_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lessons", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "social_providers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    logo_url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_social_providers", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    full_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    details = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    join_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    avatar = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    knowledge = table.Column<int>(type: "int", nullable: false),
                    reputation = table.Column<int>(type: "int", nullable: false),
                    followers_count = table.Column<int>(type: "int", nullable: false),
                    days_without_break = table.Column<int>(type: "int", nullable: false),
                    days_without_break_max = table.Column<int>(type: "int", nullable: false),
                    solved_tasks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "certificate_settings",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false),
                    logo_url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    signature_url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    is_certificate_auto_issued = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    regular_threshold = table.Column<int>(type: "int", nullable: false),
                    excellent_threshold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_certificate_settings", x => x.course_id);
                    table.ForeignKey(
                        name: "FK_certificate_settings_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "units",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units", x => x.id);
                    table.ForeignKey(
                        name: "FK_units_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "steps",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    lesson_id = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_steps", x => x.id);
                    table.ForeignKey(
                        name: "FK_steps_lessons_lesson_id",
                        column: x => x.lesson_id,
                        principalTable: "lessons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "certificates",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    grade = table.Column<int>(type: "int", nullable: false),
                    issue_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_certificates", x => new { x.user_id, x.course_id });
                    table.ForeignKey(
                        name: "FK_certificates_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_certificates_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "courses_authors",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses_authors", x => new { x.course_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_courses_authors_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_courses_authors_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_courses",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    is_favorite = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_pinned = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_archived = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    last_viewed = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_courses", x => new { x.user_id, x.course_id });
                    table.ForeignKey(
                        name: "FK_user_courses_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_courses_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_social_providers",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    social_provider_id = table.Column<int>(type: "int", nullable: false),
                    connect_url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_social_providers", x => new { x.user_id, x.social_provider_id });
                    table.ForeignKey(
                        name: "FK_user_social_providers_social_providers_social_provider_id",
                        column: x => x.social_provider_id,
                        principalTable: "social_providers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_social_providers_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "unit_lessons",
                columns: table => new
                {
                    unit_id = table.Column<int>(type: "int", nullable: false),
                    lesson_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unit_lessons", x => new { x.unit_id, x.lesson_id });
                    table.ForeignKey(
                        name: "FK_unit_lessons_lessons_lesson_id",
                        column: x => x.lesson_id,
                        principalTable: "lessons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_unit_lessons_units_unit_id",
                        column: x => x.unit_id,
                        principalTable: "units",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    step_id = table.Column<int>(type: "int", nullable: true),
                    reply_comment_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    time = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    epic_count = table.Column<int>(type: "int", nullable: false),
                    abuse_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_comments_comments_reply_comment_id",
                        column: x => x.reply_comment_id,
                        principalTable: "comments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_comments_steps_step_id",
                        column: x => x.step_id,
                        principalTable: "steps",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_comments_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "progresses",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    step_id = table.Column<int>(type: "int", nullable: false),
                    is_passed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_progresses", x => new { x.user_id, x.step_id });
                    table.ForeignKey(
                        name: "FK_progresses_steps_step_id",
                        column: x => x.step_id,
                        principalTable: "steps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_progresses_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "course_reviews",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    comment_id = table.Column<int>(type: "int", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    score = table.Column<int>(type: "int", nullable: false),
                    epic_count = table.Column<int>(type: "int", nullable: false),
                    abuse_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_reviews", x => new { x.course_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_course_reviews_comments_comment_id",
                        column: x => x.comment_id,
                        principalTable: "comments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_course_reviews_courses_course_id",
                        column: x => x.course_id,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_course_reviews_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_certificates_course_id",
                table: "certificates",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_reply_comment_id",
                table: "comments",
                column: "reply_comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_step_id",
                table: "comments",
                column: "step_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_user_id",
                table: "comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_course_reviews_comment_id",
                table: "course_reviews",
                column: "comment_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_course_reviews_user_id",
                table: "course_reviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_courses_authors_user_id",
                table: "courses_authors",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_progresses_step_id",
                table: "progresses",
                column: "step_id");

            migrationBuilder.CreateIndex(
                name: "IX_steps_lesson_id",
                table: "steps",
                column: "lesson_id");

            migrationBuilder.CreateIndex(
                name: "IX_unit_lessons_lesson_id",
                table: "unit_lessons",
                column: "lesson_id");

            migrationBuilder.CreateIndex(
                name: "IX_units_course_id",
                table: "units",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_courses_course_id",
                table: "user_courses",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_social_providers_social_provider_id",
                table: "user_social_providers",
                column: "social_provider_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "certificate_settings");

            migrationBuilder.DropTable(
                name: "certificates");

            migrationBuilder.DropTable(
                name: "course_reviews");

            migrationBuilder.DropTable(
                name: "courses_authors");

            migrationBuilder.DropTable(
                name: "progresses");

            migrationBuilder.DropTable(
                name: "unit_lessons");

            migrationBuilder.DropTable(
                name: "user_courses");

            migrationBuilder.DropTable(
                name: "user_social_providers");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "units");

            migrationBuilder.DropTable(
                name: "social_providers");

            migrationBuilder.DropTable(
                name: "steps");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "lessons");
        }
    }
}
