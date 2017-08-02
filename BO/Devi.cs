namespace Lorenzo_InterTransit_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  //  using System.Data.Entity.Spatial;

    public partial class Devi
    {
        /// <summary>
        /// classe m�tier devis
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Devi()
        {
            LigneDeVentes = new HashSet<LigneDeVente>();
        }

        [Key]
        [Display(Name = "Num�ro du devis")]
        [Required(ErrorMessage = "Le num�ro de devis est obligatoire")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DEVIS_ID { get; set; }

        [Display(Name = "Num�ro d'assurance")]
        public bool? DEVIS_ASSURANCE { get; set; }

        [Display(Name = "Date du devis")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DEVIS_DATE { get; set; }


        [Display(Name = "R�f�rence formalit�")]
        [StringLength(50, ErrorMessage = "Ce champ ne doit pas d�passer 40 caract�res maximum")]
        public string DEVIS_REF_FORM { get; set; }

        [Display(Name = "Tarif")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? DEVIS_TARIF { get; set; }

        [Display(Name = "Taux de change")]
        public decimal? DEVIS_TAUX_CHG { get; set; }

        [Display(Name = "Taux de marge")]
        public decimal? DEVIS_TAUX_MRG { get; set; }

        [Display(Name = "Total achat")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? DEVIS_TOTALACHAT { get; set; }

        [Display(Name = "Total vente")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? DEVIS_TOTALVENTE { get; set; }

        [Display(Name ="Devis ou Facture")]
        public bool? DEVIS_ETAT { get; set; }

        [Display(Name = "R�gl�")]
        public bool? DEVIS_REGLE { get; set; }

        [Display(Name = "Observation")]
        [StringLength(500, ErrorMessage = "Ce champ ne doit pas d�passer 500 caract�res maximum")]
        [DataType(DataType.MultilineText)]
        public string DEVIS_OBS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LigneDeVente> LigneDeVentes { get; set; }
    }
}
