namespace QuizCreator.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Module")]
    public partial class Module
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Module()
        {
            FormateurModuleGroupes = new HashSet<FormateurModuleGroupe>();
            PartieModules = new HashSet<PartieModule>();
            Quizes = new HashSet<Quize>();
        }

        [Key]
        public int IdModule { get; set; }

        public int? IdFilliere { get; set; }

        [StringLength(150)]
        public string ModuleName { get; set; }

        public double? Mass_Horaire { get; set; }

        [StringLength(50)]
        public string ModuleSlug { get; set; }

        public virtual Filliere Filliere { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FormateurModuleGroupe> FormateurModuleGroupes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartieModule> PartieModules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quize> Quizes { get; set; }
    }
}
