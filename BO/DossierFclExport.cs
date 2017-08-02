namespace Lorenzo_InterTransit_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   // using System.Data.Entity.Spatial;

    [Table("DossierFclExport")]
    public partial class DossierFclExport
    {
        /// <summary>
        /// classe métier dossier fcl export
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DossierFclExport()
        {
            Bookings = new HashSet<Booking>();
            InstruTransporteurs = new HashSet<InstruTransporteur>();
            LigneDeVentes = new HashSet<LigneDeVente>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name ="Num Dossier")]
        public string FCL_ID { get; set; }

        [Display(Name = "ID Client")]
        public int CLT_ID { get; set; }

        [Display(Name = "Statut du dossier FCL")]
        public bool? FCL_STATUT { get; set; }

        [Display(Name = "Date de mise à jour")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FCL_DATEMAJ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InstruTransporteur> InstruTransporteurs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LigneDeVente> LigneDeVentes { get; set; }
    }
}
