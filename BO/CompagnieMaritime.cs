namespace Lorenzo_InterTransit_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   // using System.Data.Entity.Spatial;

    [Table("CompagnieMaritime")]
    public partial class CompagnieMaritime
    {
        /// <summary>
        /// classe métier compagnie maritime
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompagnieMaritime()
        {
            Bookings = new HashSet<Booking>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Reference Compagnie Maritime")]
        [StringLength(10, ErrorMessage = "La taille doit etre inférieure à 10 caracteres")]
        public string CM_REF { get; set; }

        [Display(Name ="Raison Sociale")]
        [StringLength(30, ErrorMessage = "La taille doit etre inférieure à 30 caracteres")]
        public string CM_NOMRAIS { get; set; }

        [Display(Name ="Siret")]
        public int? CM_SIRET { get; set; }

        [Display(Name ="Adresse")]
        [StringLength(100, ErrorMessage = "La taille doit etre inférieure à 100 caracteres")]
        public string CM_ADRESSE { get; set; }

        [Display(Name ="Code Postal")]
        [DataType(DataType.PostalCode)]
        [StringLength(10, ErrorMessage = "La taille doit etre inférieure à 10 caracteres")]
        public string CM_CP { get; set; }

        [Display(Name ="Ville")]
        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        public string CM_VILLE { get; set; }

        [Display(Name ="Pays")]
        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        public string CM_PAYS { get; set; }

        [Display(Name ="Mail")]
        [DataType(DataType.EmailAddress)]
        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        public string CM_MAIL { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Telephone")]
        [StringLength(20)]
        public string CM_TEL { get; set; }

        [Display(Name ="Portable")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        public string CM_TELPORT { get; set; }

        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Fax")]
        public string CM_FAX { get; set; }

        [StringLength(500, ErrorMessage = "La taille doit etre inférieure à 500 caracteres")]
        [DataType(DataType.MultilineText)]
        [Display(Name ="Observations")]
        public string CM_OBS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
