using FluentMigrator;

namespace TaskFlow.Api.Migrations;

[Migration(2026090901)]
public class CreateTasksTable : Migration
{
    public override void Up()
    {
        Create.Table("tasks")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("title").AsString(200).NotNullable()
            .WithColumn("is_completed").AsBoolean().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("tasks");
    }
}