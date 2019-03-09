namespace Vidzy.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddTagsTableConfiguration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "Name", c => c.String());
        }
    }
}
