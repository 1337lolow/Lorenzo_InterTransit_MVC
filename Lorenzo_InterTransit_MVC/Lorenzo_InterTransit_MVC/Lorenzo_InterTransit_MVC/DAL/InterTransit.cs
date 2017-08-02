namespace Lorenzo_InterTransit_MVC.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Lorenzo_InterTransit_MVC;

    public partial class InterTransit : DbContext
    {
        public InterTransit()
            : base("name=InterTransit")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<CompagnieMaritime> CompagnieMaritimes { get; set; }
        public virtual DbSet<Conteneur> Conteneurs { get; set; }
        public virtual DbSet<Devi> Devis { get; set; }
        public virtual DbSet<DossierFclExport> DossierFclExports { get; set; }
        public virtual DbSet<InstruTransporteur> InstruTransporteurs { get; set; }
        public virtual DbSet<LigneDeVente> LigneDeVentes { get; set; }
        public virtual DbSet<MAD> MADs { get; set; }
        public virtual DbSet<Marchandise> Marchandises { get; set; }
        public virtual DbSet<NatureMarchandise> NatureMarchandises { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Transporteur> Transporteurs { get; set; }
        public virtual DbSet<TypeTC> TypeTCs { get; set; }
        public virtual DbSet<TypeTransporteur> TypeTransporteurs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.BKG_NUM)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.FCL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.CM_REF)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BKG_NOMNAVIRE)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BKG_FORWARDER)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BKG_LOADTERM)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BKG_NUMVYG)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BKG_PORTARRIVEE)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BKG_PORTDEPART)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BKG_PORTFORWARDER)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BKG_REFCOTATION)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BKG_OBS)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.BKG_REFBL)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .HasMany(e => e.Conteneurs)
                .WithRequired(e => e.Booking)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLT_REF)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLT_NOMRAIS)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLT_ADRESSE)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLT_CP)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLT_VILLE)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLT_PAYS)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLT_MAIL)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLT_TEL)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLT_TELPORT)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLT_FAX)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.CLT_OBS)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.DossierFclExports)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompagnieMaritime>()
                .Property(e => e.CM_REF)
                .IsUnicode(false);

            modelBuilder.Entity<CompagnieMaritime>()
                .Property(e => e.CM_NOMRAIS)
                .IsUnicode(false);

            modelBuilder.Entity<CompagnieMaritime>()
                .Property(e => e.CM_ADRESSE)
                .IsUnicode(false);

            modelBuilder.Entity<CompagnieMaritime>()
                .Property(e => e.CM_CP)
                .IsUnicode(false);

            modelBuilder.Entity<CompagnieMaritime>()
                .Property(e => e.CM_VILLE)
                .IsUnicode(false);

            modelBuilder.Entity<CompagnieMaritime>()
                .Property(e => e.CM_PAYS)
                .IsUnicode(false);

            modelBuilder.Entity<CompagnieMaritime>()
                .Property(e => e.CM_MAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CompagnieMaritime>()
                .Property(e => e.CM_TEL)
                .IsUnicode(false);

            modelBuilder.Entity<CompagnieMaritime>()
                .Property(e => e.CM_TELPORT)
                .IsUnicode(false);

            modelBuilder.Entity<CompagnieMaritime>()
                .Property(e => e.CM_FAX)
                .IsUnicode(false);

            modelBuilder.Entity<CompagnieMaritime>()
                .Property(e => e.CM_OBS)
                .IsUnicode(false);

            modelBuilder.Entity<CompagnieMaritime>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.CompagnieMaritime)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Conteneur>()
                .Property(e => e.BKG_NUM)
                .IsUnicode(false);

            modelBuilder.Entity<Conteneur>()
                .Property(e => e.CTN_PLOMBAGE)
                .IsUnicode(false);

            modelBuilder.Entity<Conteneur>()
                .Property(e => e.CTN_REFCOX)
                .IsUnicode(false);

            modelBuilder.Entity<Conteneur>()
                .Property(e => e.CTN_OBS)
                .IsUnicode(false);

            modelBuilder.Entity<Conteneur>()
                .HasMany(e => e.Marchandises)
                .WithMany(e => e.Conteneurs)
                .Map(m => m.ToTable("TCMarchandise").MapLeftKey("CTN_REF").MapRightKey("MARCH_ID"));

            modelBuilder.Entity<Devi>()
                .Property(e => e.DEVIS_REF_FORM)
                .IsUnicode(false);

            modelBuilder.Entity<Devi>()
                .Property(e => e.DEVIS_TARIF)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Devi>()
                .Property(e => e.DEVIS_TAUX_CHG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Devi>()
                .Property(e => e.DEVIS_TAUX_MRG)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Devi>()
                .Property(e => e.DEVIS_TOTALACHAT)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Devi>()
                .Property(e => e.DEVIS_TOTALVENTE)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Devi>()
                .Property(e => e.DEVIS_OBS)
                .IsUnicode(false);

            modelBuilder.Entity<Devi>()
                .HasMany(e => e.LigneDeVentes)
                .WithRequired(e => e.Devi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DossierFclExport>()
                .Property(e => e.FCL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<DossierFclExport>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.DossierFclExport)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DossierFclExport>()
                .HasMany(e => e.InstruTransporteurs)
                .WithRequired(e => e.DossierFclExport)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DossierFclExport>()
                .HasMany(e => e.LigneDeVentes)
                .WithRequired(e => e.DossierFclExport)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InstruTransporteur>()
                .Property(e => e.MAD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<InstruTransporteur>()
                .Property(e => e.FCL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<InstruTransporteur>()
                .Property(e => e.TRS_REF)
                .IsUnicode(false);

            modelBuilder.Entity<InstruTransporteur>()
                .Property(e => e.INSTR_ADRS_EMPTG)
                .IsUnicode(false);

            modelBuilder.Entity<InstruTransporteur>()
                .Property(e => e.INSTR_ADRS_LIVRAISION)
                .IsUnicode(false);

            modelBuilder.Entity<InstruTransporteur>()
                .Property(e => e.INSTR_LIEU_ARRIVEE)
                .IsUnicode(false);

            modelBuilder.Entity<InstruTransporteur>()
                .Property(e => e.INSTR_LIEU_DEPART)
                .IsUnicode(false);

            modelBuilder.Entity<InstruTransporteur>()
                .Property(e => e.INSTR_OBS)
                .IsUnicode(false);

            modelBuilder.Entity<LigneDeVente>()
                .Property(e => e.FCL_ID)
                .IsUnicode(false);

            modelBuilder.Entity<LigneDeVente>()
                .Property(e => e.ACHVNT_DESC_ACHAT)
                .IsUnicode(false);

            modelBuilder.Entity<LigneDeVente>()
                .Property(e => e.ACHVNT_DESC_VENTE)
                .IsUnicode(false);

            modelBuilder.Entity<LigneDeVente>()
                .Property(e => e.ACHVNT_NAT_ACHAT)
                .IsUnicode(false);

            modelBuilder.Entity<LigneDeVente>()
                .Property(e => e.ACHVNT_PRIX_ACHAT)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LigneDeVente>()
                .Property(e => e.ACHVNT_PRIX_VENTE)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LigneDeVente>()
                .Property(e => e.ACHVNT_OBS)
                .IsUnicode(false);

            modelBuilder.Entity<MAD>()
                .Property(e => e.MAD_ID)
                .IsUnicode(false);

            modelBuilder.Entity<MAD>()
                .Property(e => e.MAD_LIEU_ENLEV)
                .IsUnicode(false);

            modelBuilder.Entity<MAD>()
                .Property(e => e.MAD_ADRES_ENLEV)
                .IsUnicode(false);

            modelBuilder.Entity<MAD>()
                .Property(e => e.MAD_OBS)
                .IsUnicode(false);

            modelBuilder.Entity<MAD>()
                .HasMany(e => e.InstruTransporteurs)
                .WithRequired(e => e.MAD)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Marchandise>()
                .Property(e => e.MARCH_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<Marchandise>()
                .Property(e => e.MARCH_PDS)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Marchandise>()
                .Property(e => e.MARCH_QTE)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Marchandise>()
                .Property(e => e.MARCH_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<Marchandise>()
                .Property(e => e.MARCH_VALEURO)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Marchandise>()
                .Property(e => e.MARCH_OBS)
                .IsUnicode(false);

            modelBuilder.Entity<NatureMarchandise>()
                .Property(e => e.NAT_MARCH_LIBELLE)
                .IsUnicode(false);

            modelBuilder.Entity<NatureMarchandise>()
                .HasMany(e => e.Marchandises)
                .WithRequired(e => e.NatureMarchandise)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.TRS_REF)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.TRS_NOMRAIS)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.TRS_ADRESSE)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.TRS_CP)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.TRS_VILLE)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.TRS_PAYS)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.TRS_MAIL)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.TRS_TEL)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.TRS_TELPORT)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.TRS_FAX)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .Property(e => e.TRS_OBS)
                .IsUnicode(false);

            modelBuilder.Entity<Transporteur>()
                .HasMany(e => e.InstruTransporteurs)
                .WithRequired(e => e.Transporteur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeTC>()
                .Property(e => e.TYTC_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<TypeTC>()
                .HasMany(e => e.Conteneurs)
                .WithRequired(e => e.TypeTC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeTransporteur>()
                .Property(e => e.TYTRANS_LIBELLE)
                .IsUnicode(false);

            modelBuilder.Entity<TypeTransporteur>()
                .HasMany(e => e.Transporteurs)
                .WithRequired(e => e.TypeTransporteur)
                .WillCascadeOnDelete(false);
        }
    }
}
