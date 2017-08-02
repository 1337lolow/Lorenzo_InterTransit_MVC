namespace Lorenzo_InterTransit_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 //   using System.Data.Entity.Spatial;

    [Table("TypeTC")]
    public partial class TypeTC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeTC()
        {
            Conteneurs = new HashSet<Conteneur>();
        }

        [Key]
        [Display(Name ="ID Type TC")]
        public int TYTC_ID { get; set; }

        [Display(Name ="Type TC")]
        [StringLength(40, ErrorMessage = "La taille doit etre inférieure à 40 caracteres")]
        public string TYTC_TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Conteneur> Conteneurs { get; set; }
    }
}
