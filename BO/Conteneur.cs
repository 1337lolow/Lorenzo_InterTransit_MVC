namespace Lorenzo_InterTransit_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("Conteneur")]
    public partial class Conteneur
    {
        /// <summary>
        /// classe m�tier Conteneur
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Conteneur()
        {
            Marchandises = new HashSet<Marchandise>();
        }

        [Key]
        public int CTN_ID { get; set; }

        [Display(Name ="Reference Conteneur")]
        public int? CTN_REF { get; set; }

        [Display(Name ="Type TC")]
        public int TYTC_ID { get; set; }


        [Display(Name ="Numero de booking")]
        public int? BKG_ID { get; set; }

        [StringLength(40, ErrorMessage = "La taille doit etre inf�rieure � 40 caracteres")]
        [Display(Name ="Numero Plombage")]
        public string CTN_PLOMBAGE { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Date de plombage")]
        public DateTime? CTN_DATEPLOMBAGE { get; set; }

        [Display(Name ="Reference COX")]
        [StringLength(10)]
        public string CTN_REFCOX { get; set; }

        [Display(Name ="Observations")]
        [StringLength(500, ErrorMessage = "La taille doit etre inf�rieure � 500 caracteres")]
        public string CTN_OBS { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual TypeTC TypeTC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Marchandise> Marchandises { get; set; }
    }
}
