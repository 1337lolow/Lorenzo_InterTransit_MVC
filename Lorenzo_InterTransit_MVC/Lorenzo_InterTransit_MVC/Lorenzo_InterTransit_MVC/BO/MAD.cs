namespace Lorenzo_InterTransit_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  //  using System.Data.Entity.Spatial;

    [Table("MAD")]
    public partial class MAD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MAD()
        {
            InstruTransporteurs = new HashSet<InstruTransporteur>();
        }

        [Key]
        [StringLength(10, ErrorMessage = "La taille doit etre inférieure à 10 caracteres")]
        [Display(Name ="ID MaD")]
        public string MAD_ID { get; set; }


        [StringLength(100, ErrorMessage = "La taille doit etre inférieure à 100 caracteres")]
        [Display(Name ="Lieu d'enlevement")]
        public string MAD_LIEU_ENLEV { get; set; }

        [StringLength(100, ErrorMessage = "La taille doit etre inférieure à 100 caracteres")]
        [Display(Name ="Adresse d'enlevement")]
        public string MAD_ADRES_ENLEV { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Date de Mise à Disposition")]
        public DateTime? MAD_DATE { get; set; }

        [StringLength(500, ErrorMessage = "La taille doit etre inférieure à 500 caracteres")]
        [DataType(DataType.MultilineText)]
        [Display(Name ="Observation")]
        public string MAD_OBS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InstruTransporteur> InstruTransporteurs { get; set; }
    }
}
