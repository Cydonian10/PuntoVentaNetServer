protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.Sql(@"
        CREATE TRIGGER dbo.CreateUserOnAuth
        ON dbo.Auths
        AFTER INSERT
        AS
        BEGIN
            INSERT INTO Users (Id, Name, Email)
            SELECT
                i.Id, i.Name, i.Email
            FROM inserted i;
        END;
        ENABLE TRIGGER dbo.CreateUserOnAuth ON dbo.Auths;   
    ");
}

/// <inheritdoc />
protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.Sql("DROP TRIGGER dbo.CreateUserOnAuth");
}