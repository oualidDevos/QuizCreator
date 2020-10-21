namespace QuizCreator.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuizDB : DbContext
    {
        public QuizDB()
            : base("name=QuizDB")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<ChoixReponse> ChoixReponses { get; set; }
        public virtual DbSet<Filliere> Fillieres { get; set; }
        public virtual DbSet<Formateur> Formateurs { get; set; }
        public virtual DbSet<FormateurModuleGroupe> FormateurModuleGroupes { get; set; }
        public virtual DbSet<Groupe> Groupes { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<PartieModule> PartieModules { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Quize> Quizes { get; set; }
        public virtual DbSet<QuizeStagiaireReponse> QuizeStagiaireReponses { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Stagiaire> Stagiaires { get; set; }
        public virtual DbSet<TypeQuestion> TypeQuestions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Formateurs)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.FormateurModuleGroupes)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Quizes)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.IdAccount);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.QuizeStagiaireReponses)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Stagiaires)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Quizes1)
                .WithMany(e => e.Accounts)
                .Map(m => m.ToTable("QuizeStagiaire").MapLeftKey("IdAccount").MapRightKey("IdQuize"));

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Accounts)
                .Map(m => m.ToTable("UserRole").MapLeftKey("IdAccount").MapRightKey("IdRole"));

            modelBuilder.Entity<ChoixReponse>()
                .Property(e => e.Contenu)
                .IsUnicode(false);

            modelBuilder.Entity<Filliere>()
                .Property(e => e.FilliereName)
                .IsUnicode(false);

            modelBuilder.Entity<Filliere>()
                .Property(e => e.FilliereSlug)
                .IsUnicode(false);

            modelBuilder.Entity<Formateur>()
                .Property(e => e.CIN)
                .IsUnicode(false);

            modelBuilder.Entity<Formateur>()
                .Property(e => e.Matricule)
                .IsUnicode(false);

            modelBuilder.Entity<Formateur>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Groupe>()
                .Property(e => e.GroupeName)
                .IsUnicode(false);

            modelBuilder.Entity<Groupe>()
                .HasMany(e => e.FormateurModuleGroupes)
                .WithRequired(e => e.Groupe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.ModuleName)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.ModuleSlug)
                .IsUnicode(false);

            modelBuilder.Entity<Module>()
                .HasMany(e => e.FormateurModuleGroupes)
                .WithRequired(e => e.Module)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PartieModule>()
                .Property(e => e.PartieModuleName)
                .IsUnicode(false);

            modelBuilder.Entity<PartieModule>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<PartieModule>()
                .HasMany(e => e.PartieModule1)
                .WithOptional(e => e.PartieModule2)
                .HasForeignKey(e => e.Partie);

            modelBuilder.Entity<Question>()
                .Property(e => e.QuestionContenu)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.QuestionReponse)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.QuizeStagiaireReponses)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Quizes)
                .WithMany(e => e.Questions)
                .Map(m => m.ToTable("QuizeQuestion").MapLeftKey("IdQuestion").MapRightKey("IdQuize"));

            modelBuilder.Entity<Quize>()
                .Property(e => e.QuizeType)
                .IsUnicode(false);

            modelBuilder.Entity<Quize>()
                .HasMany(e => e.QuizeStagiaireReponses)
                .WithRequired(e => e.Quize)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuizeStagiaireReponse>()
                .Property(e => e.QSReponse)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Stagiaire>()
                .Property(e => e.CIN)
                .IsUnicode(false);

            modelBuilder.Entity<Stagiaire>()
                .Property(e => e.CEI)
                .IsUnicode(false);

            modelBuilder.Entity<TypeQuestion>()
                .Property(e => e.Type)
                .IsUnicode(false);
        }
    }
}
