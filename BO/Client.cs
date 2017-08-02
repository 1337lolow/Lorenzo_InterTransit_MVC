namespace Lorenzo_InterTransit_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   // using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        /// <summary>
        /// classe métier client
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            DossierFclExports = new HashSet<DossierFclExport>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CLT_ID { get; set; }

        [Display(Name ="Reference Client")]
        [StringLength(10, ErrorMessage = "La taille doit etre inférieure à 10 caracteres")]
        public string CLT_REF { get; set; }

        [Display(Name ="Nom ou Raison Sociale")]
        [StringLength(30, ErrorMessage = "La taille doit etre inférieure à 30 caracteres")]
        public string CLT_NOMRAIS { get; set; }

        [Display(Name ="Siret")]
        public int? CLT_SIRET { get; set; }

        [Display(Name ="Adresse")]
        [StringLength(100, ErrorMessage = "La taille doit etre inférieure à 100 caracteres")]
        public string CLT_ADRESSE { get; set; }

        [StringLength(10, ErrorMessage = "La taille doit etre inférieure à 10 caracteres")]
        [Display(Name ="Code Postal")]
        [DataType(DataType.PostalCode)]
        public string CLT_CP { get; set; }

        [Display(Name ="Ville")]
        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        public string CLT_VILLE { get; set; }

        [Display(Name ="Pays")]
        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        public string CLT_PAYS { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name ="Mail")]
        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        public string CLT_MAIL { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Telephone")]
        [StringLength(20, ErrorMessage = "La taille doit etre inférieure à 20 caracteres")]
        public string CLT_TEL { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Telephone Portable")]
        [StringLength(20, ErrorMessage = "La taille doit etre inférieure à 20 caracteres")]
        public string CLT_TELPORT { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name ="Fax")]
        [StringLength(20, ErrorMessage = "La taille doit etre inférieure à 20 caracteres")]
        public string CLT_FAX { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "La taille doit etre inférieure à 500 caracteres")]
        [Display(Name ="Observations")]
        public string CLT_OBS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DossierFclExport> DossierFclExports { get; set; }
    }
}
