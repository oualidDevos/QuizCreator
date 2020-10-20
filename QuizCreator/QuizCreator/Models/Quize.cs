namespace QuizCreator.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quize")]
    public partial class Quize
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quize()
        {
            QuizeStagiaireReponses = new HashSet<QuizeStagiaireReponse>();
            Questions = new HashSet<Question>();
            Accounts = new HashSet<Account>();
        }

        [Key]
        public int IdQuize { get; set; }

        public int? IdAccount { get; set; }

        public double? QuizeDuree { get; set; }

        public bool? QuizeValid { get; set; }

        [StringLength(50)]
        public string QuizeType { get; set; }

        public int? IdModule { get; set; }

        public virtual Account Account { get; set; }

        public virtual Module Module { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuizeStagiaireReponse> QuizeStagiaireReponses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
