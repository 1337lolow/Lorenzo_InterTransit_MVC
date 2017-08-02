namespace Lorenzo_InterTransit_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lolow4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Conteneur", new[] { "Booking_BKG_ID" });
            DropColumn("dbo.Conteneur", "BKG_ID");
            RenameColumn(table: "dbo.Conteneur", name: "Booking_BKG_ID", newName: "BKG_ID");
            AlterColumn("dbo.Conteneur", "CTN_REF", c => c.Int());
            AlterColumn("dbo.Conteneur", "BKG_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Conteneur", "BKG_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Conteneur", new[] { "BKG_ID" });
            AlterColumn("dbo.Conteneur", "BKG_ID", c => c.String(nullable: false, maxLength: 40, unicode: false));
            AlterColumn("dbo.Conteneur", "CTN_REF", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Conteneur", name: "BKG_ID", newName: "Booking_BKG_ID");
            AddColumn("dbo.Conteneur", "BKG_ID", c => c.String(nullable: false, maxLength: 40, unicode: false));
            CreateIndex("dbo.Conteneur", "Booking_BKG_ID");
        }
    }
}
