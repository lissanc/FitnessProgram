using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessProgram.Migrations
{
    /// <inheritdoc />
    public partial class AddTrainerMetadataFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    fitnessLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_pk", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Category_pk", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    equip_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Equipment_pk", x => x.equip_id);
                });

            migrationBuilder.CreateTable(
                name: "MuscleGroup",
                columns: table => new
                {
                    muscle_group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MuscleGroup_pk", x => x.muscle_group_id);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    trainer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    Certification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearsExperience = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Trainer_pk", x => x.trainer_id);
                    table.ForeignKey(
                        name: "FK_Trainer_AppUser",
                        column: x => x.userID,
                        principalTable: "AppUser",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    exercise_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    difficulty_level = table.Column<int>(type: "int", nullable: false),
                    instructions = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Exercise_pk", x => x.exercise_id);
                    table.ForeignKey(
                        name: "Exercise_Category",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "category_id");
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    goal_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    start_date = table.Column<DateOnly>(type: "date", nullable: false),
                    end_date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Goal_pk", x => x.goal_id);
                    table.ForeignKey(
                        name: "FK_Goal_Category",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "category_id");
                    table.ForeignKey(
                        name: "Goal_User",
                        column: x => x.userID,
                        principalTable: "AppUser",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "FitnessPlan",
                columns: table => new
                {
                    plan_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trainer_id = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    duration_weeks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FitnessPlan_pk", x => x.plan_ID);
                    table.ForeignKey(
                        name: "FK_FitnessPlan_AppUser",
                        column: x => x.userID,
                        principalTable: "AppUser",
                        principalColumn: "userID");
                    table.ForeignKey(
                        name: "FK_FitnessPlan_Category",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "category_id");
                    table.ForeignKey(
                        name: "FK_FitnessPlan_Trainer",
                        column: x => x.trainer_id,
                        principalTable: "Trainer",
                        principalColumn: "trainer_id");
                });

            migrationBuilder.CreateTable(
                name: "User_Trainer",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false),
                    Trainer_trainer_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_Trainer_pk", x => new { x.userID, x.Trainer_trainer_id });
                    table.ForeignKey(
                        name: "User_Trainer_Trainer",
                        column: x => x.Trainer_trainer_id,
                        principalTable: "Trainer",
                        principalColumn: "trainer_id");
                    table.ForeignKey(
                        name: "User_Trainer_User",
                        column: x => x.userID,
                        principalTable: "AppUser",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "Exercise_Equipment",
                columns: table => new
                {
                    exercise_id = table.Column<int>(type: "int", nullable: false),
                    equip_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Exercise_Equipment_pk", x => new { x.exercise_id, x.equip_id });
                    table.ForeignKey(
                        name: "Exercise_Equipment_Equipment",
                        column: x => x.equip_id,
                        principalTable: "Equipment",
                        principalColumn: "equip_id");
                    table.ForeignKey(
                        name: "Exercise_Equipment_Exercise",
                        column: x => x.exercise_id,
                        principalTable: "Exercise",
                        principalColumn: "exercise_id");
                });

            migrationBuilder.CreateTable(
                name: "Exercise_MuscleGroup",
                columns: table => new
                {
                    exercise_id = table.Column<int>(type: "int", nullable: false),
                    muscle_group_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Exercise_MuscleGroup_pk", x => new { x.exercise_id, x.muscle_group_id });
                    table.ForeignKey(
                        name: "Exercise_MuscleGroup_Exercise",
                        column: x => x.exercise_id,
                        principalTable: "Exercise",
                        principalColumn: "exercise_id");
                    table.ForeignKey(
                        name: "Exercise_MuscleGroup_MuscleGroup",
                        column: x => x.muscle_group_id,
                        principalTable: "MuscleGroup",
                        principalColumn: "muscle_group_id");
                });

            migrationBuilder.CreateTable(
                name: "Plan_Exercise",
                columns: table => new
                {
                    plan_ID = table.Column<int>(type: "int", nullable: false),
                    exercise_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Plan_Exercise_pk", x => new { x.plan_ID, x.exercise_id });
                    table.ForeignKey(
                        name: "Plan_Exercise_Exercise",
                        column: x => x.exercise_id,
                        principalTable: "Exercise",
                        principalColumn: "exercise_id");
                    table.ForeignKey(
                        name: "Plan_Exercise_FitnessPlan",
                        column: x => x.plan_ID,
                        principalTable: "FitnessPlan",
                        principalColumn: "plan_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_category_id",
                table: "Exercise",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Equipment_equip_id",
                table: "Exercise_Equipment",
                column: "equip_id");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_MuscleGroup_muscle_group_id",
                table: "Exercise_MuscleGroup",
                column: "muscle_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessPlan_category_id",
                table: "FitnessPlan",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessPlan_trainer_id",
                table: "FitnessPlan",
                column: "trainer_id");

            migrationBuilder.CreateIndex(
                name: "IX_FitnessPlan_userID",
                table: "FitnessPlan",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_category_id",
                table: "Goal",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_userID",
                table: "Goal",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Plan_Exercise_exercise_id",
                table: "Plan_Exercise",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_Trainer_userID",
                table: "Trainer",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Trainer_Trainer_trainer_id",
                table: "User_Trainer",
                column: "Trainer_trainer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise_Equipment");

            migrationBuilder.DropTable(
                name: "Exercise_MuscleGroup");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "Plan_Exercise");

            migrationBuilder.DropTable(
                name: "User_Trainer");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "MuscleGroup");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "FitnessPlan");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropTable(
                name: "AppUser");
        }
    }
}
