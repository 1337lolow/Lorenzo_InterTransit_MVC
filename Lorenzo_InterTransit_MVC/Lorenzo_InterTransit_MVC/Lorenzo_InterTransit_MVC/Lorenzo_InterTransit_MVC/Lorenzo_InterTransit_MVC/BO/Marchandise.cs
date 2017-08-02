namespace Lorenzo_InterTransit_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   // using System.Data.Entity.Spatial;

    [Table("Marchandise")]
    public partial class Marchandise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Marchandise()
        {
            Conteneurs = new HashSet<Conteneur>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="ID Marchandise")]
        public int MARCH_ID { get; set; }

        [Display(Name ="Nature Marchandise")]
        public int NAT_MARCH_ID { get; set; }

        [StringLength(100, ErrorMessage = "La taille doit etre inférieure à 100 caracteres")]
        [Display(Name ="Description Marchandise")]
        public string MARCH_DESC { get; set; }

        [Display(Name ="Poids NET Marchandise")]
        public decimal? MARCH_PDS { get; set; }

        [Display(Name ="Quantité marchandise")]
        public decimal? MARCH_QTE { get; set; }

        [Display(Name ="Type de marchandise")]
        [StringLength(100, ErrorMessage = "La taille doit etre inférieure à 100 caracteres")]
        public string MARCH_TYPE { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name ="Valeur Marchandise")]
        [Column(TypeName = "money")]
        public decimal? MARCH_VALEURO { get; set; }

        [Display(Name ="Douane OK")]
        public bool? MARCH_DOUANE { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name ="Observation")]
        [StringLength(500, ErrorMessage = "La taille doit etre inférieure à 500 caracteres")]
        public string MARCH_OBS { get; set; }

        public virtual NatureMarchandise NatureMarchandise { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Conteneur> Conteneurs { get; set; }
    }
}
