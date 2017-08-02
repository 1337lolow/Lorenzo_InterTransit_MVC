namespace Lorenzo_InterTransit_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   // using System.Data.Entity.Spatial;

    [Table("InstruTransporteur")]
    public partial class InstruTransporteur
    {
        /// <summary>
        /// classe m�tier instrutransporteur
        /// </summary>
        [Key]
        [Display(Name = "Num�ro Offre")]
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int INSTR_NUMOFR { get; set; }

        [Required]
        [Display(Name = "ID MAD")]
        [StringLength(10)]
        public string MAD_ID { get; set; }

        [Required]
        [Display(Name = "Num�ro de dossier FCL")]
        [StringLength(10)]
        public string FCL_ID { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "R�f�rence transporteur")]
        public string TRS_REF { get; set; }

        [Display(Name = "Adresse Empotage")]
        [StringLength(100, ErrorMessage = "Ce champ ne doit pas d�passer 100 caract�res maximum")]
        public string INSTR_ADRS_EMPTG { get; set; }

        [Display(Name = "Adresse Livraison")]
        [StringLength(100, ErrorMessage = "Ce champ ne doit pas d�passer 100 caract�res maximum")]
        public string INSTR_ADRS_LIVRAISION { get; set; }

        [Display(Name = "Date d'arriv�e")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? INSTR_DATEARRIVEE { get; set; }

        [Display(Name = "Date de d�part")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? INSTR_DATEDEPART { get; set; }

        [Display(Name = "Lieu d'arriv�e")]
        [StringLength(100, ErrorMessage = "Ce champ ne doit pas d�passer 100 caract�res maximum")]
        public string INSTR_LIEU_ARRIVEE { get; set; }

        [Display(Name = "Lieu de d�part")]
        [StringLength(100, ErrorMessage = "Ce champ ne doit pas d�passer 100 caract�res maximum")]
        public string INSTR_LIEU_DEPART { get; set; }

        [Display(Name = "Observation")]
        [StringLength(500, ErrorMessage = "Ce champ ne doit pas d�passer 500 caract�res maximum")]
        [DataType(DataType.MultilineText)]
        public string INSTR_OBS { get; set; }

        public virtual DossierFclExport DossierFclExport { get; set; }

        public virtual Transporteur Transporteur { get; set; }

        public virtual MAD MAD { get; set; }
    }
}
