namespace Lorenzo_InterTransit_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lolow3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Conteneur", "BKG_NUM", "dbo.Booking");
            DropForeignKey("dbo.Booking", "CM_REF", "dbo.CompagnieMaritime");
            DropForeignKey("dbo.TCMarchandise", "CTN_REF", "dbo.Conteneur");
            DropIndex("dbo.Conteneur", new[] { "BKG_NUM" });
            RenameColumn(table: "dbo.Conteneur", name: "BKG_NUM", newName: "Booking_BKG_ID");
            DropPrimaryKey("dbo.Booking");
            DropPrimaryKey("dbo.CompagnieMaritime");
            DropPrimaryKey("dbo.Conteneur");
            AddColumn("dbo.Booking", "BKG_ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Conteneur", "CTN_ID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Conteneur", "BKG_ID", c => c.String(nullable: false, maxLength: 40, unicode: false));
            AlterColumn("dbo.Booking", "BKG_NUM", c => c.String(maxLength: 40, unicode: false));
            AlterColumn("dbo.CompagnieMaritime", "CM_REF", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.Conteneur", "Booking_BKG_ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Booking", "BKG_ID");
            AddPrimaryKey("dbo.CompagnieMaritime", "CM_REF");
            AddPrimaryKey("dbo.Conteneur", "CTN_ID");
            CreateIndex("dbo.Conteneur", "Booking_BKG_ID");
            AddForeignKey("dbo.Conteneur", "Booking_BKG_ID", "dbo.Booking", "BKG_ID");
            AddForeignKey("dbo.Booking", "CM_REF", "dbo.CompagnieMaritime", "CM_REF");
            AddForeignKey("dbo.TCMarchandise", "CTN_REF", "dbo.Conteneur", "CTN_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TCMarchandise", "CTN_REF", "dbo.Conteneur");
            DropForeignKey("dbo.Booking", "CM_REF", "dbo.CompagnieMaritime");
            DropForeignKey("dbo.Conteneur", "Booking_BKG_ID", "dbo.Booking");
            DropIndex("dbo.Conteneur", new[] { "Booking_BKG_ID" });
            DropPrimaryKey("dbo.Conteneur");
            DropPrimaryKey("dbo.CompagnieMaritime");
            DropPrimaryKey("dbo.Booking");
            AlterColumn("dbo.Conteneur", "Booking_BKG_ID", c => c.String(nullable: false, maxLength: 40, unicode: false));
            AlterColumn("dbo.CompagnieMaritime", "CM_REF", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.Booking", "BKG_NUM", c => c.String(nullable: false, maxLength: 40, unicode: false));
            DropColumn("dbo.Conteneur", "BKG_ID");
            DropColumn("dbo.Conteneur", "CTN_ID");
            DropColumn("dbo.Booking", "BKG_ID");
            AddPrimaryKey("dbo.Conteneur", "CTN_REF");
            AddPrimaryKey("dbo.CompagnieMaritime", "CM_REF");
            AddPrimaryKey("dbo.Booking", "BKG_NUM");
            RenameColumn(table: "dbo.Conteneur", name: "Booking_BKG_ID", newName: "BKG_NUM");
            CreateIndex("dbo.Conteneur", "BKG_NUM");
            AddForeignKey("dbo.TCMarchandise", "CTN_REF", "dbo.Conteneur", "CTN_REF", cascadeDelete: true);
            AddForeignKey("dbo.Booking", "CM_REF", "dbo.CompagnieMaritime", "CM_REF");
            AddForeignKey("dbo.Conteneur", "BKG_NUM", "dbo.Booking", "BKG_NUM");
        }
    }
}
