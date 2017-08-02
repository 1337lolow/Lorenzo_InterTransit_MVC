namespace Lorenzo_InterTransit_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lolow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            //DropTable("dbo.TCMarchandise");
            //DropTable("dbo.Conteneur");
            //DropTable("dbo.Booking");
            

            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        BKG_ID = c.Int(nullable: false, identity: true),
                        FCL_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        CM_REF = c.String(nullable: false, maxLength: 10, unicode: false),
                        BKG_NUM = c.String(maxLength: 40, unicode: false),
                        BKG_NOMNAVIRE = c.String(maxLength: 40, unicode: false),
                        BKG_DATE = c.DateTime(),
                        BKG_ETA = c.DateTime(),
                        BKG_ETD = c.DateTime(),
                        BKG_FORWARDER = c.String(maxLength: 40, unicode: false),
                        BKG_LOADTERM = c.String(maxLength: 40, unicode: false),
                        BKG_NUMVYG = c.String(maxLength: 10, unicode: false),
                        BKG_PORTARRIVEE = c.String(maxLength: 40, unicode: false),
                        BKG_PORTDEPART = c.String(maxLength: 40, unicode: false),
                        BKG_PORTFORWARDER = c.String(maxLength: 40, unicode: false),
                        BKG_REFCOTATION = c.String(maxLength: 40, unicode: false),
                        BKG_OBS = c.String(maxLength: 500, unicode: false),
                        BKG_REFBL = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.BKG_ID)
                .ForeignKey("dbo.CompagnieMaritime", t => t.CM_REF)
                .ForeignKey("dbo.DossierFclExport", t => t.FCL_ID)
                .Index(t => t.FCL_ID)
                .Index(t => t.CM_REF);
            
            CreateTable(
                "dbo.CompagnieMaritime",
                c => new
                    {
                        CM_REF = c.String(nullable: false, maxLength: 10, unicode: false),
                        CM_NOMRAIS = c.String(maxLength: 30, unicode: false),
                        CM_SIRET = c.Int(),
                        CM_ADRESSE = c.String(maxLength: 100, unicode: false),
                        CM_CP = c.String(maxLength: 10, unicode: false),
                        CM_VILLE = c.String(maxLength: 40, unicode: false),
                        CM_PAYS = c.String(maxLength: 40, unicode: false),
                        CM_MAIL = c.String(maxLength: 40, unicode: false),
                        CM_TEL = c.String(maxLength: 20, unicode: false),
                        CM_TELPORT = c.String(maxLength: 20, unicode: false),
                        CM_FAX = c.String(maxLength: 20, unicode: false),
                        CM_OBS = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.CM_REF);
            
            CreateTable(
                "dbo.Conteneur",
                c => new
                    {
                        CTN_ID = c.Int(nullable: false, identity: true),
                        CTN_REF = c.Int(),
                        TYTC_ID = c.Int(nullable: false),
                        BKG_ID = c.Int(nullable: false),
                        CTN_PLOMBAGE = c.String(maxLength: 40, unicode: false),
                        CTN_DATEPLOMBAGE = c.DateTime(),
                        CTN_REFCOX = c.String(maxLength: 10, unicode: false),
                        CTN_OBS = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.CTN_ID)
                .ForeignKey("dbo.TypeTC", t => t.TYTC_ID)
                .ForeignKey("dbo.Booking", t => t.BKG_ID)
                .Index(t => t.TYTC_ID)
                .Index(t => t.BKG_ID);
            
            CreateTable(
                "dbo.Marchandise",
                c => new
                    {
                        MARCH_ID = c.Int(nullable: false),
                        NAT_MARCH_ID = c.Int(nullable: false),
                        MARCH_DESC = c.String(maxLength: 100, unicode: false),
                        MARCH_PDS = c.Decimal(precision: 18, scale: 0),
                        MARCH_QTE = c.Decimal(precision: 18, scale: 0),
                        MARCH_TYPE = c.String(maxLength: 100, unicode: false),
                        MARCH_VALEURO = c.Decimal(storeType: "money"),
                        MARCH_DOUANE = c.Boolean(),
                        MARCH_OBS = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.MARCH_ID)
                .ForeignKey("dbo.NatureMarchandise", t => t.NAT_MARCH_ID)
                .Index(t => t.NAT_MARCH_ID);
            
            CreateTable(
                "dbo.NatureMarchandise",
                c => new
                    {
                        NAT_MARCH_ID = c.Int(nullable: false, identity: true),
                        NAT_MARCH_LIBELLE = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.NAT_MARCH_ID);
            
            CreateTable(
                "dbo.TypeTC",
                c => new
                    {
                        TYTC_ID = c.Int(nullable: false, identity: true),
                        TYTC_TYPE = c.String(maxLength: 40, unicode: false),
                    })
                .PrimaryKey(t => t.TYTC_ID);
            
            CreateTable(
                "dbo.DossierFclExport",
                c => new
                    {
                        FCL_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        CLT_ID = c.Int(nullable: false),
                        FCL_STATUT = c.Boolean(),
                        FCL_DATEMAJ = c.DateTime(),
                    })
                .PrimaryKey(t => t.FCL_ID)
                .ForeignKey("dbo.Client", t => t.CLT_ID)
                .Index(t => t.CLT_ID);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        CLT_ID = c.Int(nullable: false, identity: true),
                        CLT_REF = c.String(maxLength: 10, unicode: false),
                        CLT_NOMRAIS = c.String(maxLength: 30, unicode: false),
                        CLT_SIRET = c.Int(),
                        CLT_ADRESSE = c.String(maxLength: 100, unicode: false),
                        CLT_CP = c.String(maxLength: 10, unicode: false),
                        CLT_VILLE = c.String(maxLength: 40, unicode: false),
                        CLT_PAYS = c.String(maxLength: 40, unicode: false),
                        CLT_MAIL = c.String(maxLength: 40, unicode: false),
                        CLT_TEL = c.String(maxLength: 20, unicode: false),
                        CLT_TELPORT = c.String(maxLength: 20, unicode: false),
                        CLT_FAX = c.String(maxLength: 20, unicode: false),
                        CLT_OBS = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.CLT_ID);
            
            CreateTable(
                "dbo.InstruTransporteur",
                c => new
                    {
                        INSTR_NUMOFR = c.Int(nullable: false),
                        MAD_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        FCL_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        TRS_REF = c.String(nullable: false, maxLength: 10, unicode: false),
                        INSTR_ADRS_EMPTG = c.String(maxLength: 100, unicode: false),
                        INSTR_ADRS_LIVRAISION = c.String(maxLength: 100, unicode: false),
                        INSTR_DATEARRIVEE = c.DateTime(),
                        INSTR_DATEDEPART = c.DateTime(),
                        INSTR_LIEU_ARRIVEE = c.String(maxLength: 100, unicode: false),
                        INSTR_LIEU_DEPART = c.String(maxLength: 100, unicode: false),
                        INSTR_OBS = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.INSTR_NUMOFR)
                .ForeignKey("dbo.MAD", t => t.MAD_ID)
                .ForeignKey("dbo.Transporteur", t => t.TRS_REF)
                .ForeignKey("dbo.DossierFclExport", t => t.FCL_ID)
                .Index(t => t.MAD_ID)
                .Index(t => t.FCL_ID)
                .Index(t => t.TRS_REF);
            
            CreateTable(
                "dbo.MAD",
                c => new
                    {
                        MAD_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        MAD_LIEU_ENLEV = c.String(maxLength: 100, unicode: false),
                        MAD_ADRES_ENLEV = c.String(maxLength: 100, unicode: false),
                        MAD_DATE = c.DateTime(),
                        MAD_OBS = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.MAD_ID);
            
            CreateTable(
                "dbo.Transporteur",
                c => new
                    {
                        TRS_REF = c.String(nullable: false, maxLength: 10, unicode: false),
                        TYTRANS_ID = c.Int(nullable: false),
                        TRS_NOMRAIS = c.String(maxLength: 30, unicode: false),
                        TRS_SIRET = c.Int(),
                        TRS_ADRESSE = c.String(maxLength: 100, unicode: false),
                        TRS_CP = c.String(maxLength: 10, unicode: false),
                        TRS_VILLE = c.String(maxLength: 40, unicode: false),
                        TRS_PAYS = c.String(maxLength: 40, unicode: false),
                        TRS_MAIL = c.String(maxLength: 40, unicode: false),
                        TRS_TEL = c.String(maxLength: 20, unicode: false),
                        TRS_TELPORT = c.String(maxLength: 20, unicode: false),
                        TRS_FAX = c.String(maxLength: 20, unicode: false),
                        TRS_OBS = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.TRS_REF)
                .ForeignKey("dbo.TypeTransporteur", t => t.TYTRANS_ID)
                .Index(t => t.TYTRANS_ID);
            
            CreateTable(
                "dbo.TypeTransporteur",
                c => new
                    {
                        TYTRANS_ID = c.Int(nullable: false, identity: true),
                        TYTRANS_LIBELLE = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.TYTRANS_ID);
            
            CreateTable(
                "dbo.LigneDeVente",
                c => new
                    {
                        ACHVNT_ID = c.Int(nullable: false, identity: true),
                        FCL_ID = c.String(nullable: false, maxLength: 10, unicode: false),
                        DEVIS_ID = c.Int(nullable: false),
                        ACHVNT_DESC_ACHAT = c.String(maxLength: 50, unicode: false),
                        ACHVNT_DESC_VENTE = c.String(maxLength: 50, unicode: false),
                        ACHVNT_NAT_ACHAT = c.String(maxLength: 50, unicode: false),
                        ACHVNT_PRIX_ACHAT = c.Decimal(storeType: "money"),
                        ACHVNT_PRIX_VENTE = c.Decimal(storeType: "money"),
                        ACHVNT_OBS = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.ACHVNT_ID)
                .ForeignKey("dbo.Devis", t => t.DEVIS_ID)
                .ForeignKey("dbo.DossierFclExport", t => t.FCL_ID)
                .Index(t => t.FCL_ID)
                .Index(t => t.DEVIS_ID);
            
            CreateTable(
                "dbo.Devis",
                c => new
                    {
                        DEVIS_ID = c.Int(nullable: false),
                        DEVIS_ASSURANCE = c.Boolean(),
                        DEVIS_DATE = c.DateTime(),
                        DEVIS_REF_FORM = c.String(maxLength: 50, unicode: false),
                        DEVIS_TARIF = c.Decimal(storeType: "money"),
                        DEVIS_TAUX_CHG = c.Decimal(precision: 18, scale: 0),
                        DEVIS_TAUX_MRG = c.Decimal(precision: 18, scale: 0),
                        DEVIS_TOTALACHAT = c.Decimal(storeType: "money"),
                        DEVIS_TOTALVENTE = c.Decimal(storeType: "money"),
                        DEVIS_ETAT = c.Boolean(),
                        DEVIS_REGLE = c.Boolean(),
                        DEVIS_OBS = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.DEVIS_ID);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.TCMarchandise",
                c => new
                    {
                        CTN_REF = c.Int(nullable: false),
                        MARCH_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CTN_REF, t.MARCH_ID })
                .ForeignKey("dbo.Conteneur", t => t.CTN_REF, cascadeDelete: true)
                .ForeignKey("dbo.Marchandise", t => t.MARCH_ID, cascadeDelete: true)
                .Index(t => t.CTN_REF)
                .Index(t => t.MARCH_ID);
            
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserLogins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.LigneDeVente", "FCL_ID", "dbo.DossierFclExport");
            DropForeignKey("dbo.LigneDeVente", "DEVIS_ID", "dbo.Devis");
            DropForeignKey("dbo.InstruTransporteur", "FCL_ID", "dbo.DossierFclExport");
            DropForeignKey("dbo.Transporteur", "TYTRANS_ID", "dbo.TypeTransporteur");
            DropForeignKey("dbo.InstruTransporteur", "TRS_REF", "dbo.Transporteur");
            DropForeignKey("dbo.InstruTransporteur", "MAD_ID", "dbo.MAD");
            DropForeignKey("dbo.DossierFclExport", "CLT_ID", "dbo.Client");
            DropForeignKey("dbo.Booking", "FCL_ID", "dbo.DossierFclExport");
            DropForeignKey("dbo.Conteneur", "BKG_ID", "dbo.Booking");
            DropForeignKey("dbo.Conteneur", "TYTC_ID", "dbo.TypeTC");
            DropForeignKey("dbo.TCMarchandise", "MARCH_ID", "dbo.Marchandise");
            DropForeignKey("dbo.TCMarchandise", "CTN_REF", "dbo.Conteneur");
            DropForeignKey("dbo.Marchandise", "NAT_MARCH_ID", "dbo.NatureMarchandise");
            DropForeignKey("dbo.Booking", "CM_REF", "dbo.CompagnieMaritime");
            DropIndex("dbo.TCMarchandise", new[] { "MARCH_ID" });
            DropIndex("dbo.TCMarchandise", new[] { "CTN_REF" });
            DropIndex("dbo.LigneDeVente", new[] { "DEVIS_ID" });
            DropIndex("dbo.LigneDeVente", new[] { "FCL_ID" });
            DropIndex("dbo.Transporteur", new[] { "TYTRANS_ID" });
            DropIndex("dbo.InstruTransporteur", new[] { "TRS_REF" });
            DropIndex("dbo.InstruTransporteur", new[] { "FCL_ID" });
            DropIndex("dbo.InstruTransporteur", new[] { "MAD_ID" });
            DropIndex("dbo.DossierFclExport", new[] { "CLT_ID" });
            DropIndex("dbo.Marchandise", new[] { "NAT_MARCH_ID" });
            DropIndex("dbo.Conteneur", new[] { "BKG_ID" });
            DropIndex("dbo.Conteneur", new[] { "TYTC_ID" });
            DropIndex("dbo.Booking", new[] { "CM_REF" });
            DropIndex("dbo.Booking", new[] { "FCL_ID" });
            DropTable("dbo.TCMarchandise");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Devis");
            DropTable("dbo.LigneDeVente");
            DropTable("dbo.TypeTransporteur");
            DropTable("dbo.Transporteur");
            DropTable("dbo.MAD");
            DropTable("dbo.InstruTransporteur");
            DropTable("dbo.Client");
            DropTable("dbo.DossierFclExport");
            DropTable("dbo.TypeTC");
            DropTable("dbo.NatureMarchandise");
            DropTable("dbo.Marchandise");
            DropTable("dbo.Conteneur");
            DropTable("dbo.CompagnieMaritime");
            DropTable("dbo.Booking");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
