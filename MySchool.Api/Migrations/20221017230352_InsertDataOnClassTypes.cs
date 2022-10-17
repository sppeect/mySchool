using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySchool.Api.Migrations
{
    public partial class InsertDataOnClassTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [ClassTypes] ([Name]) VALUES ('Português'), ('Matematica'), ('Inglês'), ('Historia'), ('Geografia'), ('Fisica'), ('Quimica'), ('Educação Fisica')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [ClassRoom] WHERE TypesId IN (SELECT Id [ClassTypes] WHERE Name IN ('Português','Matematica','Inglês', 'Historia','Geografia','Fisica', 'Quimica', 'Educação Fisica' ");
            migrationBuilder.Sql("DELETE FROM [ClassTypes] WHERE Name IN ('Português','Matematica','Inglês', 'Historia','Geografia','Fisica', 'Quimica', 'Educação Fisica' ");

        }
    }
}
