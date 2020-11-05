namespace ReplicatorDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public partial class Datasets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dataset1",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code1 = c.Int(nullable: false),
                        Value1 = c.Int(nullable: false),
                        Code2 = c.Int(nullable: false),
                        Value2 = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dataset2",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code1 = c.Int(nullable: false),
                        Value1 = c.Int(nullable: false),
                        Code2 = c.Int(nullable: false),
                        Value2 = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dataset3",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code1 = c.Int(nullable: false),
                        Value1 = c.Int(nullable: false),
                        Code2 = c.Int(nullable: false),
                        Value2 = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dataset4",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code1 = c.Int(nullable: false),
                        Value1 = c.Int(nullable: false),
                        Code2 = c.Int(nullable: false),
                        Value2 = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dataset4");
            DropTable("dbo.Dataset3");
            DropTable("dbo.Dataset2");
            DropTable("dbo.Dataset1");
        }
    }
}
