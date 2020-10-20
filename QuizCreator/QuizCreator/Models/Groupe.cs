namespace QuizCreator.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Groupe")]
    public partial class Groupe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Groupe()
        {
            Modules = new HashSet<Module>();
            Stagiaires = new HashSet<Stagiaire>();
        }

        [Key]
        public int IdGroupe { get; set; }

        public int? IdFilliere { get; set; }

        [StringLength(150)]
        public string GroupeName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? GroupeCreated { get; set; }

        public virtual Filliere Filliere { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Module> Modules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stagiaire> Stagiaires { get; set; }
    }
}
