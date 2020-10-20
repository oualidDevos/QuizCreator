namespace QuizCreator.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Formateur")]
    public partial class Formateur
    {
        [Key]
        [Column(Order = 0)]
        public int IdFormateur { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdAccount { get; set; }

        public int? IdModule { get; set; }

        [StringLength(50)]
        public string CIN { get; set; }

        [StringLength(50)]
        public string Matricule { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateAffectation { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public virtual Account Account { get; set; }

        public virtual Module Module { get; set; }
    }
}
