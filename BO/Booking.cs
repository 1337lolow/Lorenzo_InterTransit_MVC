namespace Lorenzo_InterTransit_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   // using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        /// <summary>
        /// classe métier booking
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            Conteneurs = new HashSet<Conteneur>();
        }

        [Key]
        public int BKG_ID { get; set; }

        
        [Display(Name ="Numéro de Booking")]
        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        public string BKG_NUM { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Numéro de dossier")]
        public string FCL_ID { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Reference Compagnie Maritime")]
        public string CM_REF { get; set; }

        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        [Display(Name = "Nom du navire")]
        public string BKG_NOMNAVIRE { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date du booking")]
        public DateTime? BKG_DATE { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "E.T.A")]
        public DateTime? BKG_ETA { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "E.T.D")]
        public DateTime? BKG_ETD { get; set; }

        [Display(Name = "Nom du forwarder")]
        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        public string BKG_FORWARDER { get; set; }

        [Display(Name = "Terminal de chargement")]
        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        public string BKG_LOADTERM { get; set; }

        [Display(Name = "Numero Voyage")]
        [StringLength(10, ErrorMessage = "La taille doit etre inférieure à 10 caracteres")]
        public string BKG_NUMVYG { get; set; }

        [Display(Name = "Port d'arrivé")]
        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        public string BKG_PORTARRIVEE { get; set; }


        [Display(Name = "Port de départ")]
        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        public string BKG_PORTDEPART { get; set; }

        [Display(Name = "Port d'escale")]
        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        public string BKG_PORTFORWARDER { get; set; }

        [Display(Name = "Reference Cotation")]
        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        public string BKG_REFCOTATION { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Observations")]
        [StringLength(500, ErrorMessage = "La taille doit etre inférieure à 500 caracteres")]
        public string BKG_OBS { get; set; }

        [StringLength(20, ErrorMessage = "La taille doit etre inférieure à 20 caracteres")]
        [Display(Name ="Ref. B/L")]
        public string BKG_REFBL { get; set; }

        public virtual CompagnieMaritime CompagnieMaritime { get; set; }

        public virtual DossierFclExport DossierFclExport { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Conteneur> Conteneurs { get; set; }
    }
}
