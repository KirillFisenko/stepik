using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace stepik.Migrations
{
    /// <inheritdoc />
    public partial class InitPG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    summary = table.Column<string>(type: "text", nullable: false),
                    photo = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "lessons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    epic_count = table.Column<int>(type: "integer", nullable: false),
                    abuse_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lessons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "news",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "social_providers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    logo_url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_social_providers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    details = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    join_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    avatar = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    knowledge = table.Column<int>(type: "integer", nullable: false),
                    reputation = table.Column<int>(type: "integer", nullable: false),
                    followers_count = table.Column<int>(type: "integer", nullable: false),
                    days_without_break = table.Column<int>(type: "integer", nullable: false),
                    days_without_break_max = table.Column<int>(type: "integer", nullable: false),
                    solved_tasks = table.Column<int>(type: "integer", nullable: false),
                    about_me = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "certificate_settings",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    logo_url = table.Column<string>(type: "text", nullable: false),
                    signature_url = table.Column<string>(type: "text", nullable: false),
                    is_certificate_auto_issued = table.Column<bool>(type: "boolean", nullable: false),
                    regular_threshold = table.Column<int>(type: "integer", nullable: false),
                    excellent_threshold = table.Column<int>(type: "integer", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "units",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "steps",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lesson_id = table.Column<int>(type: "integer", nullable: false),
                    position = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    cost = table.Column<int>(type: "integer", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "certificates",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    grade = table.Column<int>(type: "integer", nullable: false),
                    issue_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "courses_authors",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "user_courses",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    is_favorite = table.Column<bool>(type: "boolean", nullable: false),
                    is_pinned = table.Column<bool>(type: "boolean", nullable: false),
                    is_archived = table.Column<bool>(type: "boolean", nullable: false),
                    last_viewed = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "user_social_providers",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    social_provider_id = table.Column<int>(type: "integer", nullable: false),
                    connect_url = table.Column<string>(type: "text", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "unit_lessons",
                columns: table => new
                {
                    unit_id = table.Column<int>(type: "integer", nullable: false),
                    lesson_id = table.Column<int>(type: "integer", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    step_id = table.Column<int>(type: "integer", nullable: true),
                    reply_comment_id = table.Column<int>(type: "integer", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    epic_count = table.Column<int>(type: "integer", nullable: false),
                    abuse_count = table.Column<int>(type: "integer", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "progresses",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    step_id = table.Column<int>(type: "integer", nullable: false),
                    is_passed = table.Column<bool>(type: "boolean", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "course_reviews",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "integer", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    comment_id = table.Column<int>(type: "integer", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    score = table.Column<int>(type: "integer", nullable: false),
                    epic_count = table.Column<int>(type: "integer", nullable: false),
                    abuse_count = table.Column<int>(type: "integer", nullable: false)
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
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "id", "created_date", "photo", "price", "summary", "title" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course4.jpg", 6000m, "Курс для начинающих веб-разработчиков", "JavaScript для начинающих" },
                    { 2, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course5.jpg", 4000m, "Курс по верстке сайтов", "Введение в HTML и CSS" },
                    { 3, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course6.jpg", 7000m, "Курс по созданию динамических сайтов", "PHP для начинающих" },
                    { 4, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course7.jpg", 9000m, "Курс по разработке мобильных приложений", "Разработка мобильных приложений на Android" },
                    { 5, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course8.jpg", 10000m, "Курс по разработке мобильных приложений", "Разработка мобильных приложений на iOS" },
                    { 6, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course9.jpg", 5000m, "Курс по работе с базами данных", "Введение в SQL" },
                    { 7, new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course10.jpg", 3000m, "Курс по работе с системами контроля версий", "Введение в Git и GitHub" },
                    { 8, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course11.jpg", 4000m, "Курс по работе с операционной системой Linux", "Введение в Linux" },
                    { 9, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course26.jpg", 5000m, "Курс по основам сетевых технологий и безопасности", "Введение в безопасность" },
                    { 10, new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course27.jpg", 1000m, "Курс поразработке и сопровождению программного обеспечения", "DevOps для начинающих" },
                    { 11, new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course14.jpg", 6000m, "Курс по тестированию программного обеспечения", "Введение в тестирование ПО" },
                    { 12, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course15.jpg", 9000m, "Курс по управлению проектами", "Введение в проектный менеджмент" },
                    { 13, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course16.jpg", 10000m, "Курс по анализу данных", "Введение в аналитику данных" },
                    { 14, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course17.jpg", 12000m, "Курс по машинному обучению", "Введение в машинное обучение" },
                    { 15, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course18.jpg", 15000m, "Курс по искусственному интеллекту", "Введение в искусственный интеллект" },
                    { 16, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course19.jpg", 7000m, "Курс по компьютерной графике", "Введение в компьютерную графику" },
                    { 17, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course20.jpg", 5000m, "Курс по дизайну сайтов", "Введение в веб-дизайн" },
                    { 18, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course21.jpg", 8000m, "Курс по маркетингу", "Введение в маркетинг" },
                    { 19, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course22.jpg", 11000m, "Курс по управлению продуктом", "Введение в управление продуктом" },
                    { 20, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course23.jpg", 14000m, "Курс по системному администрированию", "Введение в системное администрирование" },
                    { 21, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course24.jpg", 13000m, "Курс по сетевому администрированию", "Введение в сетевое администрирование" },
                    { 22, new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course25.jpg", 16000m, "Курс по разработке игр", "Введение в разработку игр" },
                    { 23, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course26.jpg", 18000m, "Курс по виртуальной реальности", "Введение в виртуальную реальность" },
                    { 24, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course27.jpg", 20000m, "Курс по дополненной реальности", "Введение в дополненную реальность" },
                    { 25, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course28.jpg", 22000m, "Курс по блокчейн-технологиям", "Введение в блокчейн" },
                    { 26, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course29.jpg", 25000m, "Курс по криптовалютам", "Введение в криптовалюты" },
                    { 27, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course30.jpg", 28000m, "Курс по искусственным нейронным сетям", "Введение в искусственную нейронную сеть" },
                    { 28, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course10.jpg", 4000m, "Курс по работе с системами контроля версий", "Введение в Git" },
                    { 29, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course11.jpg", 6000m, "Курс по работе с операционной системой Linux", "Введение в Linux" },
                    { 30, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course12.jpg", 8000m, "Курс по основам сетевых технологий и безопасности", "Введение в сети и безопасность" },
                    { 31, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course13.jpg", 11000m, "Курс по разработке и сопровождению программного обеспечения", "Введение в DevOps" },
                    { 32, new DateTime(2021, 11, 9, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/course14.jpg", 8000m, "Курс по тестированию программного обеспечения", "Введение в тестирование" }
                });

            migrationBuilder.InsertData(
                table: "lessons",
                columns: new[] { "id", "abuse_count", "epic_count", "title" },
                values: new object[,]
                {
                    { 1, 0, 10, "Lesson 1" },
                    { 2, 1, 15, "Lesson 2" },
                    { 3, 2, 20, "Lesson 3" },
                    { 4, 3, 25, "Lesson 4" },
                    { 5, 4, 30, "Lesson 5" },
                    { 6, 5, 35, "Lesson 6" },
                    { 7, 6, 40, "Lesson 7" },
                    { 8, 7, 45, "Lesson 8" },
                    { 9, 8, 50, "Lesson 9" },
                    { 10, 9, 55, "Lesson 10" },
                    { 11, 10, 60, "Lesson 11" },
                    { 12, 11, 65, "Lesson 12" },
                    { 13, 12, 70, "Lesson 13" },
                    { 14, 13, 75, "Lesson 14" },
                    { 15, 14, 80, "Lesson 15" },
                    { 16, 15, 85, "Lesson 16" },
                    { 17, 16, 90, "Lesson 17" },
                    { 18, 17, 95, "Lesson 18" },
                    { 19, 18, 100, "Lesson 19" },
                    { 20, 19, 105, "Lesson 20" },
                    { 21, 20, 110, "Lesson 21" },
                    { 22, 21, 115, "Lesson 22" },
                    { 23, 22, 120, "Lesson 23" },
                    { 24, 23, 125, "Lesson 24" },
                    { 25, 24, 130, "Lesson 25" },
                    { 26, 25, 135, "Lesson 26" },
                    { 27, 26, 140, "Lesson 27" },
                    { 28, 27, 145, "Lesson 28" },
                    { 29, 28, 150, "Lesson 29" },
                    { 30, 29, 155, "Lesson 30" },
                    { 31, 30, 160, "Lesson 31" },
                    { 32, 31, 165, "Lesson 32" }
                });

            migrationBuilder.InsertData(
                table: "social_providers",
                columns: new[] { "id", "logo_url", "name" },
                values: new object[,]
                {
                    { 1, "https://example.com/facebook_logo.png", "Facebook" },
                    { 2, "https://example.com/github_logo.png", "GitHub" },
                    { 3, "https://example.com/vk_logo.png", "VK" },
                    { 4, "https://example.com/twitter_logo.png", "Twitter" },
                    { 5, "https://example.com/coursera_logo.png", "Coursera" },
                    { 6, "https://example.com/edx_logo.png", "edX" },
                    { 7, "https://example.com/instagram_logo.png", "Instagram" },
                    { 8, "https://example.com/skype_logo.png", "Skype" },
                    { 9, "https://example.com/telegram_logo.png", "Telegram" },
                    { 10, "https://example.com/website_logo.png", "Website" },
                    { 11, "https://example.com/youtube_logo.png", "YouTube" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "about_me", "avatar", "days_without_break", "days_without_break_max", "details", "followers_count", "full_name", "is_active", "join_date", "knowledge", "reputation", "solved_tasks" },
                values: new object[,]
                {
                    { 1, null, "https://example.com/avatar4.jpg", 8, 12, "Разработчик игр", 30, "Петр Васильев", true, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 150, 75, 45 },
                    { 2, null, "https://example.com/avatar5.jpg", 3, 5, "Дизайнер", 10, "Елена Кузнецова", true, new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), 75, 25, 15 },
                    { 3, null, "https://example.com/avatar6.jpg", 0, 18, "Менеджер проектов", 60, "Алексей Соколов", false, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 250, 125, 80 },
                    { 4, null, "https://example.com/avatar7.jpg", 6, 10, "Тестировщик", 25, "Екатерина Борисова", true, new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), 125, 60, 35 },
                    { 5, null, "https://example.com/avatar8.jpg", 4, 8, "Системный администратор", 40, "Максим Александров", true, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), 200, 100, 50 },
                    { 6, null, "https://example.com/avatar9.jpg", 0, 22, "Менеджер продукта", 75, "Наталья Иванова", false, new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), 300, 150, 95 },
                    { 7, null, "https://example.com/avatar10.jpg", 5, 9, "Аналитик данных", 50, "Андрей Петров", true, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 225, 110, 65 },
                    { 8, null, "https://example.com/avatar11.jpg", 7, 11, "Маркетолог", 35, "Елизавета Смирнова", true, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 175, 85, 40 },
                    { 9, null, "https://example.com/avatar12.jpg", 0, 25, "Разработчик ПО", 65, "Артем Кузнецов", false, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), 275, 135, 100 },
                    { 10, null, "https://example.com/avatar13.jpg", 9, 14, "Дизайнер", 20, "Анна Соколова", true, new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), 100, 50, 30 },
                    { 11, null, "https://example.com/avatar14.jpg", 5, 10, "Тестировщик", 25, "Сергей Борисов", true, new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), 125, 60, 35 },
                    { 12, null, "https://example.com/avatar15.jpg", 7, 12, "Разработчик игр", 30, "Мария Александрова", true, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 150, 75, 45 },
                    { 13, null, "https://example.com/avatar16.jpg", 0, 18, "Менеджер проектов", 60, "Даниил Иванов", false, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 250, 125, 80 },
                    { 14, null, "https://example.com/avatar17.jpg", 4, 8, "Аналитик данных", 50, "Виктория Петрова", true, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), 225, 110, 50 },
                    { 15, null, "https://example.com/avatar18.jpg", 6, 10, "Маркетолог", 35, "Николай Кузнецов", true, new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 175, 85, 35 },
                    { 16, null, "https://example.com/avatar19.jpg", 0, 22, "Системный администратор", 75, "Ольга Соколова", false, new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), 300, 150, 95 },
                    { 17, null, "https://example.com/avatar20.jpg", 5, 9, "Менеджер продукта", 65, "Михаил Борисов", true, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), 275, 135, 65 },
                    { 18, null, "https://example.com/avatar21.jpg", 4, 8, "Разработчик ПО", 40, "Александр Александров", false, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), 200, 100, 50 },
                    { 19, null, "https://example.com/avatar22.jpg", 8, 12, "Дизайнер", 20, "Анна Кузнецова", true, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), 100, 50, 45 },
                    { 20, null, "https://example.com/avatar23.jpg", 5, 10, "Тестировщик", 25, "Игорь Петров", true, new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 125, 60, 35 },
                    { 21, null, "https://example.com/avatar24.jpg", 0, 18, "Менеджер проектов", 60, "Елена Борисова", false, new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), 250, 125, 80 },
                    { 22, null, "https://example.com/avatar25.jpg", 4, 8, "Аналитик данных", 50, "Александр Смирнов", true, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), 225, 110, 50 },
                    { 23, null, "https://example.com/avatar26.jpg", 6, 10, "Маркетолог", 35, "Ирина Соколова", true, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Utc), 175, 85, 35 },
                    { 24, null, "https://example.com/avatar27.jpg", 0, 22, "Системный администратор", 75, "Алексей Иванов", false, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 300, 150, 95 },
                    { 25, null, "https://example.com/avatar28.jpg", 5, 9, "Менеджер продукта", 65, "Владислав Петров", true, new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 275, 135, 65 },
                    { 26, null, "https://example.com/avatar37.jpg", 4, 8, "Менеджер продукта", 44, "Екатерина Кузнецова", false, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), 220, 160, 50 },
                    { 27, null, "https://example.com/avatar30.jpg", 8, 12, "Дизайнер", 20, "Максим Борисов", false, new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), 100, 50, 45 },
                    { 28, null, "https://example.com/avatar16.jpg", 0, 18, "Менеджер проектов", 60, "Даниил Иванов", false, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 250, 125, 80 },
                    { 29, null, "https://example.com/avatar17.jpg", 5, 9, "Разработчик ПО", 65, "Владислав Петров", true, new DateTime(2022, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), 275, 135, 65 },
                    { 30, null, "https://example.com/avatar18.jpg", 8, 12, "Дизайнер", 20, "Екатерина Кузнецова", true, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), 100, 50, 45 },
                    { 31, null, "https://example.com/avatar19.jpg", 0, 22, "Менеджер продукта", 75, "Максим Борисов", false, new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc), 300, 150, 95 },
                    { 32, null, "https://example.com/avatar20.jpg", 4, 8, "Разработчик ПО", 40, "Александр Александров", true, new DateTime(2022, 6, 28, 0, 0, 0, 0, DateTimeKind.Utc), 521, 100, 50 }
                });

            migrationBuilder.InsertData(
                table: "certificate_settings",
                columns: new[] { "course_id", "excellent_threshold", "is_certificate_auto_issued", "logo_url", "regular_threshold", "signature_url" },
                values: new object[,]
                {
                    { 1, 90, true, "https://example.com/course1_logo.png", 70, "https://example.com/course1_signature.png" },
                    { 2, 85, false, "https://example.com/course2_logo.png", 65, "https://example.com/course2_signature.png" },
                    { 5, 90, true, "https://example.com/course5_logo.png", 70, "https://example.com/course5_signature.png" },
                    { 6, 85, false, "https://example.com/course6_logo.png", 65, "https://example.com/course6_signature.png" },
                    { 7, 95, true, "https://example.com/course7_logo.png", 75, "https://example.com/course7_signature.png" },
                    { 8, 80, false, "https://example.com/course8_logo.png", 60, "https://example.com/course8_signature.png" },
                    { 9, 90, true, "https://example.com/course9_logo.png", 70, "https://example.com/course9_signature.png" },
                    { 11, 95, true, "https://example.com/course11_logo.png", 75, "https://example.com/course11_signature.png" },
                    { 12, 80, false, "https://example.com/course12_logo.png", 60, "https://example.com/course12_signature.png" },
                    { 13, 90, true, "https://example.com/course13_logo.png", 70, "https://example.com/course13_signature.png" },
                    { 17, 90, true, "https://example.com/course17_logo.png", 70, "https://example.com/course17_signature.png" },
                    { 18, 85, false, "https://example.com/course18_logo.png", 65, "https://example.com/course18_signature.png" },
                    { 20, 80, false, "https://example.com/course20_logo.png", 60, "https://example.com/course20_signature.png" }
                });

            migrationBuilder.InsertData(
                table: "certificates",
                columns: new[] { "course_id", "user_id", "grade", "issue_date", "url" },
                values: new object[,]
                {
                    { 1, 1, 95, new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate1.pdf" },
                    { 2, 1, 85, new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate2.pdf" },
                    { 3, 1, 70, new DateTime(2021, 1, 19, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate3.pdf" },
                    { 4, 2, 90, new DateTime(2021, 1, 26, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate4.pdf" },
                    { 5, 2, 80, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate5.pdf" },
                    { 6, 3, 95, new DateTime(2021, 2, 9, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate6.pdf" },
                    { 7, 3, 85, new DateTime(2021, 2, 16, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate7.pdf" },
                    { 8, 4, 90, new DateTime(2021, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate8.pdf" },
                    { 9, 4, 80, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate9.pdf" },
                    { 10, 5, 95, new DateTime(2021, 3, 9, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate10.pdf" },
                    { 11, 5, 85, new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate11.pdf" },
                    { 12, 5, 70, new DateTime(2021, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate12.pdf" },
                    { 13, 6, 90, new DateTime(2021, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate13.pdf" },
                    { 14, 6, 80, new DateTime(2021, 4, 6, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate14.pdf" },
                    { 15, 7, 95, new DateTime(2021, 4, 13, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate15.pdf" },
                    { 16, 7, 85, new DateTime(2021, 4, 20, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate16.pdf" },
                    { 17, 7, 70, new DateTime(2021, 4, 27, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate17.pdf" },
                    { 18, 8, 90, new DateTime(2021, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate18.pdf" },
                    { 19, 8, 80, new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate19.pdf" },
                    { 20, 9, 95, new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate20.pdf" },
                    { 21, 9, 85, new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate21.pdf" },
                    { 22, 9, 70, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate22.pdf" },
                    { 23, 10, 90, new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate23.pdf" },
                    { 24, 10, 80, new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate24.pdf" },
                    { 25, 11, 95, new DateTime(2021, 6, 22, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate25.pdf" },
                    { 26, 11, 85, new DateTime(2021, 6, 29, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate26.pdf" },
                    { 27, 11, 70, new DateTime(2021, 7, 6, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate27.pdf" },
                    { 28, 12, 90, new DateTime(2021, 7, 13, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate28.pdf" },
                    { 29, 12, 80, new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate29.pdf" },
                    { 1, 13, 85, new DateTime(2021, 8, 3, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate31.pdf" },
                    { 30, 13, 95, new DateTime(2021, 7, 27, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate30.pdf" },
                    { 2, 14, 90, new DateTime(2021, 8, 10, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate32.pdf" },
                    { 3, 14, 80, new DateTime(2021, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate33.pdf" },
                    { 4, 15, 95, new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate34.pdf" },
                    { 5, 15, 85, new DateTime(2021, 8, 31, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate35.pdf" },
                    { 6, 16, 90, new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate36.pdf" },
                    { 7, 16, 80, new DateTime(2021, 9, 14, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate37.pdf" },
                    { 8, 17, 95, new DateTime(2021, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate38.pdf" },
                    { 9, 17, 85, new DateTime(2021, 9, 28, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate39.pdf" },
                    { 10, 18, 90, new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate40.pdf" },
                    { 11, 18, 80, new DateTime(2021, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate41.pdf" },
                    { 12, 19, 95, new DateTime(2021, 10, 19, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate42.pdf" },
                    { 13, 19, 85, new DateTime(2021, 10, 26, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate43.pdf" },
                    { 14, 20, 90, new DateTime(2021, 11, 2, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate44.pdf" },
                    { 15, 20, 80, new DateTime(2021, 11, 9, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate45.pdf" },
                    { 16, 21, 95, new DateTime(2021, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate46.pdf" },
                    { 17, 21, 85, new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate47.pdf" },
                    { 18, 22, 90, new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate48.pdf" },
                    { 19, 22, 80, new DateTime(2021, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate49.pdf" },
                    { 20, 23, 95, new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate50.pdf" },
                    { 21, 23, 85, new DateTime(2021, 12, 21, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate51.pdf" },
                    { 22, 24, 90, new DateTime(2021, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate52.pdf" },
                    { 23, 24, 80, new DateTime(2022, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate53.pdf" },
                    { 24, 25, 95, new DateTime(2022, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate54.pdf" },
                    { 25, 25, 85, new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate55.pdf" },
                    { 26, 26, 90, new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate56.pdf" },
                    { 27, 26, 80, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate57.pdf" },
                    { 28, 27, 95, new DateTime(2022, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate58.pdf" },
                    { 29, 27, 85, new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate59.pdf" },
                    { 1, 28, 80, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate61.pdf" },
                    { 30, 28, 90, new DateTime(2022, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate60.pdf" },
                    { 2, 29, 95, new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate62.pdf" },
                    { 3, 29, 85, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate63.pdf" },
                    { 4, 30, 90, new DateTime(2022, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate64.pdf" },
                    { 5, 30, 80, new DateTime(2022, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), "https://example.com/certificate65.pdf" }
                });

            migrationBuilder.InsertData(
                table: "comments",
                columns: new[] { "id", "abuse_count", "epic_count", "reply_comment_id", "step_id", "text", "time", "user_id" },
                values: new object[,]
                {
                    { 11, 0, 1, null, null, "thank you", new DateTime(2023, 11, 9, 0, 0, 0, 0, DateTimeKind.Utc), 11 },
                    { 12, 0, 0, null, null, "thank you very much!", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), 12 }
                });

            migrationBuilder.InsertData(
                table: "course_reviews",
                columns: new[] { "course_id", "user_id", "abuse_count", "comment_id", "created_date", "epic_count", "score", "text" },
                values: new object[,]
                {
                    { 1, 3, 1, null, new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), 5, 3, "Could use more practical examples." },
                    { 2, 4, 1, null, new DateTime(2023, 10, 4, 0, 0, 0, 0, DateTimeKind.Utc), 7, 4, "Excellent content, but some steps are confusing." },
                    { 2, 5, 0, null, new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), 9, 5, "The instructor is very knowledgeable." },
                    { 3, 6, 0, null, new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Utc), 12, 5, "This course is perfect for beginners." },
                    { 3, 7, 0, null, new DateTime(2023, 10, 7, 0, 0, 0, 0, DateTimeKind.Utc), 10, 4, "I learned a lot from this course." },
                    { 4, 8, 0, null, new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Utc), 11, 5, "The course is well-organized and easy to follow." },
                    { 4, 9, 1, null, new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), 6, 3, "Some topics could be explained in more detail." },
                    { 5, 10, 0, null, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), 13, 5, "This course exceeded my expectations." }
                });

            migrationBuilder.InsertData(
                table: "courses_authors",
                columns: new[] { "course_id", "user_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 4 },
                    { 5, 4 },
                    { 6, 4 },
                    { 7, 4 },
                    { 8, 4 },
                    { 9, 9 },
                    { 10, 9 },
                    { 11, 11 },
                    { 12, 11 },
                    { 13, 11 },
                    { 14, 11 },
                    { 15, 11 },
                    { 16, 11 },
                    { 17, 11 },
                    { 18, 11 },
                    { 19, 19 },
                    { 20, 19 },
                    { 21, 19 },
                    { 22, 19 },
                    { 23, 23 },
                    { 24, 24 },
                    { 25, 24 },
                    { 26, 24 },
                    { 27, 24 },
                    { 28, 24 },
                    { 29, 24 },
                    { 30, 24 }
                });

            migrationBuilder.InsertData(
                table: "steps",
                columns: new[] { "id", "content", "cost", "lesson_id", "position", "title" },
                values: new object[,]
                {
                    { 1, "Content 1", 2, 1, 1, "Title 1" },
                    { 2, "Content 2", 2, 1, 2, "Title 2" },
                    { 3, "Content 3", 2, 1, 3, "Title 3" },
                    { 4, "Content 4", 2, 1, 4, "Title 4" },
                    { 5, "Content 1", 2, 2, 1, "Title 1" },
                    { 6, "Content 2", 2, 2, 2, "Title 2" },
                    { 7, "Content 3", 2, 2, 3, "Title 3" },
                    { 8, "Content 4", 2, 2, 4, "Title 4" },
                    { 9, "Content 1", 2, 3, 1, "Title 1" },
                    { 10, "Content 2", 2, 3, 2, "Title 2" },
                    { 11, "Content 3", 2, 3, 3, "Title 3" },
                    { 12, "Content 4", 2, 3, 4, "Title 4" },
                    { 13, "Content 1", 2, 4, 1, "Title 1" },
                    { 14, "Content 2", 2, 4, 2, "Title 2" },
                    { 15, "Content 3", 2, 4, 3, "Title 3" },
                    { 16, "Content 4", 2, 4, 4, "Title 4" },
                    { 17, "Content 1", 2, 5, 1, "Title 1" },
                    { 18, "Content 2", 2, 5, 2, "Title 2" },
                    { 19, "Content 3", 2, 5, 3, "Title 3" },
                    { 20, "Content 4", 2, 5, 4, "Title 4" },
                    { 21, "Content 1", 2, 6, 1, "Title 1" },
                    { 22, "Content 2", 2, 6, 2, "Title 2" },
                    { 23, "Content 3", 2, 6, 3, "Title 3" },
                    { 24, "Content 4", 2, 6, 4, "Title 4" },
                    { 25, "Content 1", 2, 7, 1, "Title 1" },
                    { 26, "Content 2", 2, 7, 2, "Title 2" },
                    { 27, "Content 3", 2, 7, 3, "Title 3" },
                    { 28, "Content 4", 2, 7, 4, "Title 4" },
                    { 29, "Content 1", 2, 8, 1, "Title 1" },
                    { 30, "Content 2", 2, 8, 2, "Title 2" },
                    { 31, "Content 3", 2, 8, 3, "Title 3" },
                    { 32, "Content 4", 2, 8, 4, "Title 4" }
                });

            migrationBuilder.InsertData(
                table: "units",
                columns: new[] { "id", "course_id", "title" },
                values: new object[,]
                {
                    { 1, 1, "Unit 1 for Course 1" },
                    { 2, 1, "Unit 2 for Course 1" },
                    { 3, 2, "Unit 1 for Course 2" },
                    { 4, 2, "Unit 2 for Course 2" },
                    { 5, 3, "Unit 1 for Course 3" },
                    { 6, 3, "Unit 2 for Course 3" },
                    { 7, 4, "Unit 1 for Course 4" },
                    { 8, 4, "Unit 2 for Course 4" },
                    { 9, 5, "Unit 1 for Course 5" },
                    { 10, 5, "Unit 2 for Course 5" },
                    { 11, 6, "Unit 1 for Course 6" },
                    { 12, 6, "Unit 2 for Course 6" },
                    { 13, 7, "Unit 1 for Course 7" },
                    { 14, 7, "Unit 2 for Course 7" },
                    { 15, 8, "Unit 1 for Course 8" },
                    { 16, 8, "Unit 2 for Course 8" },
                    { 17, 9, "Unit 1 for Course 9" },
                    { 18, 9, "Unit 2 for Course 9" },
                    { 19, 10, "Unit 1 for Course 10" },
                    { 20, 10, "Unit 2 for Course 10" },
                    { 21, 11, "Unit 1 for Course 11" },
                    { 22, 11, "Unit 2 for Course 11" },
                    { 23, 12, "Unit 1 for Course 12" },
                    { 24, 12, "Unit 2 for Course 12" },
                    { 25, 13, "Unit 1 for Course 13" },
                    { 26, 13, "Unit 2 for Course 13" },
                    { 27, 14, "Unit 1 for Course 14" },
                    { 28, 14, "Unit 2 for Course 14" },
                    { 29, 15, "Unit 1 for Course 15" },
                    { 30, 15, "Unit 2 for Course 15" },
                    { 31, 16, "Unit 1 for Course 16" },
                    { 32, 16, "Unit 2 for Course 16" },
                    { 33, 17, "Unit 1 for Course 17" },
                    { 34, 17, "Unit 2 for Course 17" },
                    { 35, 18, "Unit 1 for Course 18" },
                    { 36, 18, "Unit 2 for Course 18" },
                    { 37, 19, "Unit 1 for Course 19" },
                    { 38, 19, "Unit 2 for Course 19" },
                    { 39, 20, "Unit 1 for Course 20" },
                    { 40, 20, "Unit 2 for Course 20" },
                    { 41, 21, "Unit 1 for Course 21" },
                    { 42, 21, "Unit 2 for Course 21" },
                    { 43, 22, "Unit 1 for Course 22" },
                    { 44, 22, "Unit 2 for Course 22" },
                    { 45, 23, "Unit 1 for Course 23" },
                    { 46, 23, "Unit 2 for Course 23" },
                    { 47, 24, "Unit 1 for Course 24" },
                    { 48, 24, "Unit 2 for Course 24" },
                    { 49, 25, "Unit 1 for Course 25" },
                    { 50, 25, "Unit 2 for Course 25" },
                    { 51, 26, "Unit 1 for Course 26" },
                    { 52, 26, "Unit 2 for Course 26" },
                    { 53, 27, "Unit 1 for Course 27" },
                    { 54, 27, "Unit 2 for Course 27" },
                    { 55, 28, "Unit 1 for Course 28" },
                    { 56, 28, "Unit 2 for Course 28" },
                    { 57, 29, "Unit 1 for Course 29" },
                    { 58, 29, "Unit 2 for Course 29" },
                    { 59, 30, "Unit 1 for Course 30" },
                    { 60, 30, "Unit 2 for Course 30" },
                    { 61, 31, "Unit 1 for Course 31" },
                    { 62, 31, "Unit 2 for Course 31" },
                    { 63, 32, "Unit 1 for Course 32" },
                    { 64, 32, "Unit 2 for Course 32" }
                });

            migrationBuilder.InsertData(
                table: "user_courses",
                columns: new[] { "course_id", "user_id", "is_archived", "is_favorite", "is_pinned", "last_viewed" },
                values: new object[,]
                {
                    { 1, 1, false, true, false, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 1, false, false, true, new DateTime(2021, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 1, true, false, false, new DateTime(2021, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, 2, false, true, true, new DateTime(2021, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 2, true, false, false, new DateTime(2021, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, 3, false, true, false, new DateTime(2021, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, 3, false, false, true, new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, 4, false, true, true, new DateTime(2021, 2, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, 4, true, false, false, new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, 5, false, true, false, new DateTime(2021, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, 5, false, false, true, new DateTime(2021, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, 5, true, false, false, new DateTime(2021, 3, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, 6, false, true, true, new DateTime(2021, 3, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, 6, true, false, false, new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, 7, false, true, false, new DateTime(2021, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 16, 7, false, false, true, new DateTime(2021, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 17, 7, true, false, false, new DateTime(2021, 4, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 18, 8, false, true, true, new DateTime(2021, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 19, 8, true, false, false, new DateTime(2021, 5, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, 9, false, true, false, new DateTime(2021, 5, 13, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 21, 9, false, false, true, new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 22, 9, true, false, false, new DateTime(2021, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 23, 10, false, true, true, new DateTime(2021, 6, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 24, 10, true, false, false, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 25, 11, false, true, false, new DateTime(2021, 6, 17, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 26, 11, false, false, true, new DateTime(2021, 6, 24, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 27, 11, true, false, false, new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 28, 12, false, true, true, new DateTime(2021, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 29, 12, true, false, false, new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 1, 13, false, false, true, new DateTime(2021, 7, 29, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 30, 13, false, true, false, new DateTime(2021, 7, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 14, false, true, false, new DateTime(2021, 8, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 14, true, false, false, new DateTime(2021, 8, 12, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, 15, false, true, true, new DateTime(2021, 8, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 15, true, false, false, new DateTime(2021, 8, 26, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, 16, false, true, false, new DateTime(2021, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, 16, false, false, true, new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, 17, false, true, true, new DateTime(2021, 9, 16, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, 17, true, false, false, new DateTime(2021, 9, 23, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, 18, false, true, false, new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 11, 18, false, false, true, new DateTime(2021, 10, 7, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 12, 19, false, true, true, new DateTime(2021, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 13, 19, true, false, false, new DateTime(2021, 10, 21, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, 20, false, true, false, new DateTime(2021, 10, 28, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 15, 20, false, false, true, new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 16, 21, false, true, true, new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 17, 21, true, false, false, new DateTime(2021, 11, 18, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 18, 22, false, true, false, new DateTime(2021, 11, 25, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 19, 22, false, false, true, new DateTime(2021, 12, 2, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 20, 23, false, true, true, new DateTime(2021, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 21, 23, true, false, false, new DateTime(2021, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 22, 24, false, true, false, new DateTime(2021, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 23, 24, false, false, true, new DateTime(2021, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 24, 25, false, true, true, new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 25, 25, true, false, false, new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 26, 26, false, true, false, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 27, 26, false, false, true, new DateTime(2022, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 28, 27, false, true, true, new DateTime(2022, 2, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 29, 27, true, false, false, new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 1, 28, false, false, true, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 30, 28, false, true, false, new DateTime(2022, 2, 17, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 29, false, true, false, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, 29, true, false, false, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, 30, false, true, true, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 30, true, false, false, new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "user_social_providers",
                columns: new[] { "social_provider_id", "user_id", "connect_url" },
                values: new object[,]
                {
                    { 1, 1, "https://www.facebook.com/user1" },
                    { 2, 1, "https://github.com/user1" },
                    { 3, 1, "https://vk.com/user1" },
                    { 4, 1, "https://twitter.com/user1" },
                    { 5, 1, "https://www.coursera.org/user/user1" },
                    { 6, 1, "https://courses.edx.org/u/user1" },
                    { 7, 1, "https://www.instagram.com/user1" },
                    { 8, 2, "skype:user2" },
                    { 9, 2, "https://t.me/user2" },
                    { 10, 2, "https://www.user2.com" },
                    { 11, 2, "https://www.youtube.com/user2" },
                    { 1, 3, "https://www.facebook.com/user3" },
                    { 2, 3, "https://github.com/user3" },
                    { 3, 3, "https://vk.com/user3" },
                    { 4, 3, "https://twitter.com/user3" },
                    { 9, 3, "https://t.me/user3" },
                    { 10, 3, "https://www.user3.com" },
                    { 11, 3, "https://www.youtube.com/user3" },
                    { 1, 4, "https://www.facebook.com/user4" },
                    { 2, 4, "https://github.com/user4" },
                    { 7, 4, "https://www.instagram.com/user4" },
                    { 8, 4, "skype:user4" },
                    { 9, 4, "https://t.me/user4" },
                    { 10, 4, "https://www.user4.com" },
                    { 11, 4, "https://www.youtube.com/user4" },
                    { 1, 5, "https://www.facebook.com/user5" },
                    { 2, 5, "https://github.com/user5" },
                    { 3, 5, "https://vk.com/user5" },
                    { 4, 5, "https://twitter.com/user5" },
                    { 5, 5, "https://www.coursera.org/user/user5" },
                    { 6, 5, "https://courses.edx.org/u/user5" },
                    { 7, 5, "https://www.instagram.com/user5" },
                    { 8, 5, "skype:user5" },
                    { 9, 5, "https://t.me/user5" },
                    { 10, 5, "https://www.user5.com" },
                    { 11, 5, "https://www.youtube.com/user5" },
                    { 1, 6, "https://www.facebook.com/user6" },
                    { 2, 6, "https://github.com/user6" },
                    { 3, 6, "https://vk.com/user6" },
                    { 4, 6, "https://twitter.com/user6" },
                    { 5, 6, "https://www.coursera.org/user/user6" },
                    { 6, 6, "https://courses.edx.org/u/user6" },
                    { 1, 8, "https://www.facebook.com/user8" },
                    { 2, 8, "https://github.com/user8" },
                    { 3, 8, "https://vk.com/user8" },
                    { 4, 8, "https://twitter.com/user8" },
                    { 6, 8, "https://courses.edx.org/u/user8" },
                    { 7, 8, "https://www.instagram.com/user8" },
                    { 8, 8, "skype:user8" },
                    { 9, 8, "https://t.me/user8" },
                    { 10, 8, "https://www.user8.com" },
                    { 11, 8, "https://www.youtube.com/user8" },
                    { 1, 9, "https://www.facebook.com/user9" },
                    { 2, 9, "https://github.com/user9" },
                    { 8, 9, "skype:user9" },
                    { 9, 9, "https://t.me/user9" },
                    { 10, 9, "https://www.user9.com" },
                    { 11, 9, "https://www.youtube.com/user9" },
                    { 1, 10, "https://www.facebook.com/user10" },
                    { 7, 10, "https://www.instagram.com/user10" },
                    { 8, 10, "skype:user10" },
                    { 9, 10, "https://t.me/user10" },
                    { 10, 10, "https://www.user10.com" },
                    { 11, 10, "https://www.youtube.com/user10" },
                    { 1, 11, "https://www.facebook.com/user11" },
                    { 2, 11, "https://github.com/user11" },
                    { 3, 11, "https://vk.com/user11" },
                    { 4, 11, "https://twitter.com/user11" },
                    { 5, 11, "https://www.coursera.org/user/user11" },
                    { 6, 11, "https://courses.edx.org/u/user11" },
                    { 7, 11, "https://www.instagram.com/user11" },
                    { 1, 12, "https://www.facebook.com/user12" },
                    { 2, 12, "https://github.com/user12" },
                    { 4, 12, "https://twitter.com/user12" },
                    { 5, 12, "https://www.coursera.org/user/user12" },
                    { 6, 12, "https://courses.edx.org/u/user12" },
                    { 7, 12, "https://www.instagram.com/user12" },
                    { 8, 12, "skype:user12" },
                    { 10, 12, "https://www.user12.com" },
                    { 11, 12, "https://www.youtube.com/user12" },
                    { 1, 13, "https://www.facebook.com/user13" },
                    { 2, 13, "https://github.com/user13" },
                    { 3, 13, "https://vk.com/user13" },
                    { 4, 13, "https://twitter.com/user13" },
                    { 8, 13, "skype:user13" },
                    { 9, 13, "https://t.me/user13" },
                    { 10, 13, "https://www.user13.com" },
                    { 11, 13, "https://www.youtube.com/user13" },
                    { 1, 16, "https://www.facebook.com/user16" },
                    { 2, 16, "https://github.com/user16" },
                    { 3, 16, "https://vk.com/user16" },
                    { 6, 16, "https://courses.edx.org/u/user16" },
                    { 7, 16, "https://www.instagram.com/user16" },
                    { 8, 16, "skype:user16" },
                    { 9, 16, "https://t.me/user16" },
                    { 10, 16, "https://www.user16.com" },
                    { 11, 16, "https://www.youtube.com/user16" },
                    { 3, 21, "https://vk.com/user21" },
                    { 4, 21, "https://twitter.com/user21" },
                    { 5, 21, "https://www.coursera.org/user/user21" },
                    { 6, 21, "https://courses.edx.org/u/user21" },
                    { 7, 21, "https://www.instagram.com/user21" },
                    { 8, 21, "skype:user21" },
                    { 9, 21, "https://t.me/user21" },
                    { 10, 21, "https://www.user21.com" },
                    { 11, 21, "https://www.youtube.com/user21" },
                    { 1, 22, "https://www.facebook.com/user22" },
                    { 2, 22, "https://github.com/user22" },
                    { 3, 22, "https://vk.com/user22" },
                    { 4, 22, "https://twitter.com/user22" },
                    { 5, 22, "https://www.coursera.org/user/user22" },
                    { 6, 22, "https://courses.edx.org/u/user22" },
                    { 7, 22, "https://www.instagram.com/user22" },
                    { 10, 22, "https://www.user22.com" },
                    { 11, 22, "https://www.youtube.com/user22" },
                    { 1, 23, "https://www.facebook.com/user23" },
                    { 2, 23, "https://github.com/user23" },
                    { 3, 23, "https://vk.com/user23" },
                    { 4, 23, "https://twitter.com/user23" },
                    { 5, 23, "https://www.coursera.org/user/user23" },
                    { 6, 23, "https://courses.edx.org/u/user23" },
                    { 7, 23, "https://www.instagram.com/user23" },
                    { 8, 23, "skype:user23" },
                    { 9, 23, "https://t.me/user23" },
                    { 10, 23, "https://www.user23.com" },
                    { 11, 23, "https://www.youtube.com/user23" },
                    { 1, 27, "https://www.facebook.com/user27" },
                    { 6, 27, "https://courses.edx.org/u/user27" },
                    { 7, 27, "https://www.instagram.com/user27" },
                    { 8, 27, "skype:user27" },
                    { 9, 27, "https://t.me/user27" },
                    { 10, 27, "https://www.user27.com" },
                    { 11, 27, "https://www.youtube.com/user27" },
                    { 1, 28, "https://www.facebook.com/user28" }
                });

            migrationBuilder.InsertData(
                table: "comments",
                columns: new[] { "id", "abuse_count", "epic_count", "reply_comment_id", "step_id", "text", "time", "user_id" },
                values: new object[,]
                {
                    { 1, 0, 5, null, 1, "Great step!", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 2, 0, 3, null, 1, "I agree, very helpful.", new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 4, 1, 1, null, 2, "This step is a bit confusing.", new DateTime(2023, 10, 4, 0, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 6, 0, 6, null, 3, "Excellent content!", new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Utc), 6 },
                    { 8, 1, 2, null, 4, "Could use more examples.", new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Utc), 8 },
                    { 10, 0, 7, null, 5, "This step is perfect!", new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc), 10 }
                });

            migrationBuilder.InsertData(
                table: "course_reviews",
                columns: new[] { "course_id", "user_id", "abuse_count", "comment_id", "created_date", "epic_count", "score", "text" },
                values: new object[,]
                {
                    { 1, 1, 0, 11, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), 10, 5, "Great course! Highly recommend." },
                    { 1, 2, 0, 12, new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Utc), 8, 4, "Very informative and well-structured." }
                });

            migrationBuilder.InsertData(
                table: "progresses",
                columns: new[] { "step_id", "user_id", "is_passed", "score" },
                values: new object[,]
                {
                    { 1, 1, true, 1 },
                    { 2, 1, true, 1 },
                    { 3, 1, false, 0 },
                    { 4, 1, true, 1 },
                    { 1, 2, false, 0 },
                    { 2, 2, true, 1 },
                    { 3, 2, true, 1 },
                    { 4, 2, true, 1 },
                    { 1, 3, true, 2 },
                    { 2, 3, true, 2 },
                    { 3, 3, true, 1 },
                    { 4, 3, true, 1 },
                    { 1, 4, true, 2 },
                    { 2, 4, true, 1 },
                    { 3, 4, false, 0 },
                    { 4, 4, false, 0 },
                    { 1, 5, true, 1 },
                    { 2, 5, true, 2 },
                    { 3, 5, true, 2 },
                    { 4, 5, true, 1 },
                    { 1, 6, true, 1 },
                    { 2, 6, false, 0 },
                    { 3, 6, true, 2 },
                    { 4, 6, true, 1 },
                    { 1, 7, true, 1 },
                    { 2, 7, false, 0 },
                    { 3, 7, true, 2 },
                    { 4, 7, true, 1 },
                    { 1, 8, true, 1 },
                    { 2, 8, true, 2 },
                    { 3, 8, true, 2 },
                    { 4, 8, true, 2 },
                    { 1, 9, true, 2 },
                    { 2, 9, true, 2 },
                    { 3, 9, true, 2 },
                    { 4, 9, true, 2 },
                    { 1, 10, true, 2 },
                    { 2, 10, true, 2 },
                    { 3, 10, true, 2 },
                    { 4, 10, true, 2 },
                    { 1, 11, true, 2 },
                    { 2, 11, true, 2 },
                    { 3, 11, true, 2 },
                    { 4, 11, true, 2 },
                    { 1, 12, true, 2 },
                    { 2, 12, true, 1 },
                    { 3, 12, false, 0 },
                    { 4, 12, false, 0 },
                    { 1, 13, false, 0 },
                    { 2, 13, false, 0 },
                    { 3, 13, false, 0 },
                    { 4, 13, false, 0 },
                    { 1, 14, true, 1 },
                    { 2, 14, true, 1 },
                    { 3, 14, true, 1 },
                    { 4, 14, true, 2 },
                    { 1, 15, true, 2 },
                    { 2, 15, true, 2 },
                    { 3, 15, true, 2 },
                    { 4, 15, true, 2 },
                    { 1, 16, true, 2 },
                    { 2, 16, true, 2 },
                    { 3, 16, true, 2 },
                    { 4, 16, true, 1 },
                    { 1, 17, true, 1 },
                    { 2, 17, true, 2 },
                    { 3, 17, false, 0 },
                    { 4, 17, false, 0 },
                    { 1, 18, true, 1 },
                    { 2, 18, true, 2 },
                    { 3, 18, true, 1 },
                    { 4, 18, true, 2 },
                    { 1, 19, true, 1 },
                    { 2, 19, true, 2 },
                    { 3, 19, true, 2 },
                    { 4, 19, true, 2 },
                    { 1, 20, true, 2 },
                    { 2, 20, true, 2 },
                    { 3, 20, true, 2 },
                    { 4, 20, true, 2 },
                    { 1, 21, true, 2 },
                    { 2, 21, true, 1 },
                    { 3, 21, true, 2 },
                    { 4, 21, true, 2 },
                    { 1, 22, true, 2 },
                    { 2, 22, false, 0 },
                    { 3, 22, false, 0 },
                    { 4, 22, false, 0 },
                    { 1, 23, true, 1 },
                    { 2, 23, true, 1 },
                    { 3, 23, true, 2 },
                    { 4, 23, true, 2 },
                    { 1, 24, true, 2 },
                    { 2, 24, true, 2 },
                    { 3, 24, true, 2 },
                    { 4, 24, true, 2 },
                    { 1, 25, true, 2 },
                    { 2, 25, true, 2 },
                    { 3, 25, false, 0 },
                    { 4, 25, true, 1 },
                    { 1, 26, false, 0 },
                    { 2, 26, true, 2 },
                    { 3, 26, true, 2 },
                    { 4, 26, true, 2 },
                    { 1, 27, true, 2 },
                    { 2, 27, true, 2 },
                    { 3, 27, true, 2 },
                    { 4, 27, true, 2 },
                    { 1, 28, true, 2 },
                    { 2, 28, true, 2 },
                    { 3, 28, true, 2 },
                    { 4, 28, true, 2 },
                    { 1, 29, true, 2 },
                    { 2, 29, true, 2 },
                    { 3, 29, true, 2 },
                    { 4, 29, true, 2 },
                    { 1, 30, true, 2 },
                    { 2, 30, false, 0 },
                    { 3, 30, true, 2 },
                    { 4, 30, false, 0 },
                    { 1, 31, true, 1 },
                    { 2, 31, true, 1 },
                    { 3, 31, true, 1 },
                    { 4, 31, false, 0 },
                    { 1, 32, false, 0 },
                    { 2, 32, false, 0 },
                    { 3, 32, false, 0 },
                    { 4, 32, false, 0 }
                });

            migrationBuilder.InsertData(
                table: "unit_lessons",
                columns: new[] { "lesson_id", "unit_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 3 },
                    { 6, 3 },
                    { 7, 4 },
                    { 8, 4 },
                    { 9, 5 },
                    { 10, 5 },
                    { 11, 6 },
                    { 12, 6 },
                    { 13, 7 },
                    { 14, 7 },
                    { 15, 8 },
                    { 16, 8 },
                    { 17, 9 },
                    { 18, 9 },
                    { 19, 10 },
                    { 20, 10 },
                    { 21, 11 },
                    { 22, 11 },
                    { 23, 12 },
                    { 24, 12 },
                    { 25, 13 },
                    { 26, 13 },
                    { 27, 14 },
                    { 28, 14 },
                    { 29, 15 },
                    { 30, 15 },
                    { 31, 16 },
                    { 32, 16 },
                    { 1, 17 },
                    { 2, 17 },
                    { 3, 18 },
                    { 4, 18 },
                    { 5, 19 },
                    { 6, 19 },
                    { 7, 20 },
                    { 8, 20 },
                    { 9, 21 },
                    { 10, 21 },
                    { 11, 22 },
                    { 12, 22 },
                    { 13, 23 },
                    { 14, 23 },
                    { 15, 24 },
                    { 16, 24 },
                    { 17, 25 },
                    { 18, 25 },
                    { 19, 26 },
                    { 20, 26 },
                    { 21, 27 },
                    { 22, 27 },
                    { 23, 28 },
                    { 24, 28 },
                    { 25, 29 },
                    { 26, 29 },
                    { 27, 30 },
                    { 28, 30 },
                    { 29, 31 },
                    { 30, 31 },
                    { 31, 32 },
                    { 32, 32 },
                    { 1, 33 },
                    { 2, 33 },
                    { 3, 34 },
                    { 4, 34 },
                    { 5, 35 },
                    { 6, 35 },
                    { 7, 36 },
                    { 8, 36 },
                    { 9, 37 },
                    { 10, 37 },
                    { 11, 38 },
                    { 12, 38 },
                    { 13, 39 },
                    { 14, 39 },
                    { 15, 40 },
                    { 16, 40 },
                    { 17, 41 },
                    { 18, 41 },
                    { 19, 42 },
                    { 20, 42 },
                    { 21, 43 },
                    { 22, 43 },
                    { 23, 44 },
                    { 24, 44 },
                    { 25, 45 },
                    { 26, 45 },
                    { 27, 46 },
                    { 28, 46 },
                    { 29, 47 },
                    { 30, 47 },
                    { 31, 48 },
                    { 32, 48 },
                    { 1, 49 },
                    { 2, 49 },
                    { 3, 50 },
                    { 4, 50 },
                    { 5, 51 },
                    { 6, 51 },
                    { 7, 52 },
                    { 8, 52 },
                    { 9, 53 },
                    { 10, 53 },
                    { 11, 54 },
                    { 12, 54 },
                    { 13, 55 },
                    { 14, 55 },
                    { 15, 56 },
                    { 16, 56 },
                    { 17, 57 },
                    { 18, 57 },
                    { 19, 58 },
                    { 20, 58 },
                    { 21, 59 },
                    { 22, 59 },
                    { 23, 60 },
                    { 24, 60 },
                    { 25, 61 },
                    { 26, 61 },
                    { 27, 62 },
                    { 28, 62 },
                    { 29, 63 },
                    { 30, 63 },
                    { 31, 64 },
                    { 32, 64 }
                });

            migrationBuilder.InsertData(
                table: "comments",
                columns: new[] { "id", "abuse_count", "epic_count", "reply_comment_id", "step_id", "text", "time", "user_id" },
                values: new object[,]
                {
                    { 3, 0, 2, 1, 1, "Thanks for the feedback!", new DateTime(2023, 10, 3, 0, 0, 0, 0, DateTimeKind.Utc), 3 },
                    { 5, 0, 4, 4, 2, "I can help explain it if you need.", new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Utc), 5 },
                    { 7, 0, 3, 6, 3, "Glad you found it useful!", new DateTime(2023, 10, 7, 0, 0, 0, 0, DateTimeKind.Utc), 7 },
                    { 9, 0, 5, 8, 4, "I will add more examples in the next update.", new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), 9 }
                });

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
                name: "news");

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
