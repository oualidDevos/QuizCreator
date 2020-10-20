namespace QuizCreator.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PartieModule")]
    public partial class PartieModule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PartieModule()
        {
            PartieModule1 = new HashSet<PartieModule>();
            Questions = new HashSet<Question>();
        }

        [Key]
        public int IdPartieModule { get; set; }

        public int? IdModule { get; set; }

        [StringLength(150)]
        public string PartieModuleName { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int? Partie { get; set; }

        public virtual Module Module { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PartieModule> PartieModule1 { get; set; }

        public virtual PartieModule PartieModule2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }
    }
}
