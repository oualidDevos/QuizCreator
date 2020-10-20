namespace QuizCreator.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stagiaire")]
    public partial class Stagiaire
    {
        [Key]
        [Column(Order = 0)]
        public int IdStagiaire { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdAccount { get; set; }

        [StringLength(50)]
        public string CIN { get; set; }

        [StringLength(50)]
        public string CEI { get; set; }

        public int? IdGroupe { get; set; }

        public virtual Account Account { get; set; }

        public virtual Groupe Groupe { get; set; }
    }
}
