namespace Lorenzo_InterTransit_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  //  using System.Data.Entity.Spatial;

    [Table("Transporteur")]
    public partial class Transporteur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transporteur()
        {
            InstruTransporteurs = new HashSet<InstruTransporteur>();
        }

        [Key]
        [StringLength(10)]
        [Display(Name ="ID Transporteur")]
        public string TRS_REF { get; set; }


        public int TYTRANS_ID { get; set; }

        [StringLength(30, ErrorMessage = "La taille doit etre inférieure à 30 caracteres")]
        [Display(Name ="Raison Sociale")]
        public string TRS_NOMRAIS { get; set; }

        [Display(Name ="Siret")]
        public int? TRS_SIRET { get; set; }

        [StringLength(100, ErrorMessage = "La taille doit etre inférieure à 100 caracteres")]
        [Display(Name ="Adresse")]
        public string TRS_ADRESSE { get; set; }

        [StringLength(10, ErrorMessage = "La taille doit etre inférieure à 10 caracteres")]
        [DataType(DataType.PostalCode)]
        public string TRS_CP { get; set; }

        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        [Display(Name ="Ville")]
        public string TRS_VILLE { get; set; }

        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        [Display(Name ="Pays")]
        public string TRS_PAYS { get; set; }

        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Mail")]
        public string TRS_MAIL { get; set; }

        [StringLength(20, ErrorMessage = "La taille doit etre inférieure à 20 caracteres")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Telephone")]
        public string TRS_TEL { get; set; }

        [StringLength(20, ErrorMessage = "La taille doit etre inférieure à 20 caracteres")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Portable")]
        public string TRS_TELPORT { get; set; }

        [StringLength(20, ErrorMessage = "La taille doit etre inférieure à 20 caracteres")]
        [Display(Name ="Fax")]
        [DataType(DataType.PhoneNumber)]
        public string TRS_FAX { get; set; }

        [StringLength(500, ErrorMessage = "La taille doit etre inférieure à 500 caracteres")]
        [Display(Name ="Observation")]
        [DataType(DataType.MultilineText)]
        public string TRS_OBS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InstruTransporteur> InstruTransporteurs { get; set; }

        public virtual TypeTransporteur TypeTransporteur { get; set; }
    }
}
