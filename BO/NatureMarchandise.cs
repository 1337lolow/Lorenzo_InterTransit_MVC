namespace Lorenzo_InterTransit_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  //  using System.Data.Entity.Spatial;

    [Table("NatureMarchandise")]
    public partial class NatureMarchandise
    {
        /// <summary>
        /// classe métier nature marchandise
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NatureMarchandise()
        {
            Marchandises = new HashSet<Marchandise>();
        }

        [Key]
        [Display(Name ="ID Nature Marchandise")]
        public int NAT_MARCH_ID { get; set; }

        [StringLength(100, ErrorMessage = "La taille doit etre inférieure à 100 caracteres")]
        [Display(Name ="Nature de Marchandise")]
        public string NAT_MARCH_LIBELLE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Marchandise> Marchandises { get; set; }
    }
}
