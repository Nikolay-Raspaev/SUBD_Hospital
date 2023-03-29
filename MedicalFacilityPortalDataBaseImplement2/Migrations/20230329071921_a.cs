using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalFacilityPortalDataBaseImplement2.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    jobtitle = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("jobs_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    surname = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    passportseries = table.Column<int>(type: "integer", nullable: false),
                    passportnumber = table.Column<int>(type: "integer", nullable: false),
                    telephonenumber = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("patients_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("services_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    surname = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    passportseries = table.Column<int>(type: "integer", nullable: false),
                    passportnumber = table.Column<int>(type: "integer", nullable: false),
                    telephonenumber = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    education = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    jobid = table.Column<int>(type: "integer", nullable: false),
                    academicdegree = table.Column<int>(type: "integer", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("doctors_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fkdoctorsjob",
                        column: x => x.jobid,
                        principalTable: "jobs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "servicesjobs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    servicesid = table.Column<int>(type: "integer", nullable: false),
                    jobid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("servicesjobs_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fkservicesjobjob",
                        column: x => x.jobid,
                        principalTable: "jobs",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fkservicesjobservices",
                        column: x => x.servicesid,
                        principalTable: "services",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "doctorsservices",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    doctorsid = table.Column<int>(type: "integer", nullable: false),
                    servicesid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("doctorsservices_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fkdoctorsservicesdoctors",
                        column: x => x.servicesid,
                        principalTable: "services",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fkdoctorsservicesservices",
                        column: x => x.doctorsid,
                        principalTable: "doctors",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "contracts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    exercisedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    executionstatus = table.Column<int>(type: "integer", maxLength: 50, nullable: false),
                    patientid = table.Column<int>(type: "integer", nullable: false),
                    doctorsservicesid = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("contracts_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fkcontractdoctorsservices",
                        column: x => x.doctorsservicesid,
                        principalTable: "doctorsservices",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fkcontractpatient",
                        column: x => x.patientid,
                        principalTable: "patients",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_contracts_doctorsservicesid",
                table: "contracts",
                column: "doctorsservicesid");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_patientid",
                table: "contracts",
                column: "patientid");

            migrationBuilder.CreateIndex(
                name: "IX_doctors_jobid",
                table: "doctors",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "doctorsservices_doctorsid_servicesid_key",
                table: "doctorsservices",
                columns: new[] { "doctorsid", "servicesid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_doctorsservices_servicesid",
                table: "doctorsservices",
                column: "servicesid");

            migrationBuilder.CreateIndex(
                name: "IX_servicesjobs_jobid",
                table: "servicesjobs",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_servicesjobs_servicesid",
                table: "servicesjobs",
                column: "servicesid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contracts");

            migrationBuilder.DropTable(
                name: "servicesjobs");

            migrationBuilder.DropTable(
                name: "doctorsservices");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "jobs");
        }
    }
}
