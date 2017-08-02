namespace Lorenzo_InterTransit_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   // using System.Data.Entity.Spatial;

    [Table("LigneDeVente")]
    public partial class LigneDeVente
    {
        [Key]
        [Display(Name ="ID Ligne de Vente")]
        public int ACHVNT_ID { get; set; }

        [Required]
        [Display(Name ="ID Dossier")]
        [StringLength(10, ErrorMessage = "La taille doit etre inférieure à 10 caracteres")]
        public string FCL_ID { get; set; }

        [Display(Name ="Numéro de devis")]
        public int DEVIS_ID { get; set; }

        [Display(Name ="Description achat")]
        [StringLength(50, ErrorMessage = "La taille doit etre inférieure à 50 caracteres")]
        public string ACHVNT_DESC_ACHAT { get; set; }

        [Display(Name ="Description Vente")]
        [StringLength(50, ErrorMessage = "La taille doit etre inférieure à 50 caracteres")]
        public string ACHVNT_DESC_VENTE { get; set; }

        [Display(Name = "Nature achat")]
        [StringLength(50, ErrorMessage = "La taille doit etre inférieure à 50 caracteres")]
        public string ACHVNT_NAT_ACHAT { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name ="Prix d'achat")]
        [Column(TypeName = "money")]
        public decimal? ACHVNT_PRIX_ACHAT { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name ="Prix de vente")]
        [Column(TypeName = "money")]
        public decimal? ACHVNT_PRIX_VENTE { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name ="Observation")]
        [StringLength(500, ErrorMessage = "La taille doit etre inférieure à 500 caracteres")]
        public string ACHVNT_OBS { get; set; }

        public virtual Devi Devi { get; set; }

        public virtual DossierFclExport DossierFclExport { get; set; }
    }
}
