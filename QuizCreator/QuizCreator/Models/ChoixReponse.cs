namespace QuizCreator.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChoixReponse")]
    public partial class ChoixReponse
    {
        [Key]
        public int IdChoixReponse { get; set; }

        [StringLength(50)]
        public string Contenu { get; set; }

        public int? IdQuestion { get; set; }

        public virtual Question Question { get; set; }
    }
}
