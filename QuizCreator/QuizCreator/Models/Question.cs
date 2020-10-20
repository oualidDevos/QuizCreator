namespace QuizCreator.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            ChoixReponses = new HashSet<ChoixReponse>();
            QuizeStagiaireReponses = new HashSet<QuizeStagiaireReponse>();
            Quizes = new HashSet<Quize>();
        }

        [Key]
        public int IdQuestion { get; set; }

        public int? IdAccount { get; set; }

        public string QuestionContenu { get; set; }

        public string QuestionReponse { get; set; }

        public bool? Etat { get; set; }

        public bool? Accessibilite { get; set; }

        public int? Niveau { get; set; }

        public int? IdPartieModule { get; set; }

        public int? IdTypeQuestion { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChoixReponse> ChoixReponses { get; set; }

        public virtual PartieModule PartieModule { get; set; }

        public virtual TypeQuestion TypeQuestion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuizeStagiaireReponse> QuizeStagiaireReponses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quize> Quizes { get; set; }
    }
}
