namespace QuizCreator.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuizeStagiaireReponse")]
    public partial class QuizeStagiaireReponse
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdQuize { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdAccount { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdQuestion { get; set; }

        [StringLength(1000)]
        public string QSReponse { get; set; }

        public virtual Account Account { get; set; }

        public virtual Question Question { get; set; }

        public virtual Quize Quize { get; set; }
    }
}
