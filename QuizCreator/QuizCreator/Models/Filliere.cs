namespace QuizCreator.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Filliere")]
    public partial class Filliere
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Filliere()
        {
            Groupes = new HashSet<Groupe>();
        }

        [Key]
        public int IdFilliere { get; set; }

        [StringLength(150)]
        public string FilliereName { get; set; }

        [StringLength(150)]
        public string FilliereSlug { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Groupe> Groupes { get; set; }
    }
}
