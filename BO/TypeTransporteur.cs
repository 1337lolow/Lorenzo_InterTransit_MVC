namespace Lorenzo_InterTransit_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  //  using System.Data.Entity.Spatial;

    [Table("TypeTransporteur")]
    public partial class TypeTransporteur
    {
        /// <summary>
        /// Classe métier Type de transporteur
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeTransporteur()
        {
            Transporteurs = new HashSet<Transporteur>();
        }

        [Key]
        [Display(Name ="Type de Transporteur")]
        public int TYTRANS_ID { get; set; }

        [StringLength(50, ErrorMessage = "La taille doit etre inférieure à 50 caracteres")]
        [Display(Name ="Type de transporteur")]
        public string TYTRANS_LIBELLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transporteur> Transporteurs { get; set; }
    }
}
