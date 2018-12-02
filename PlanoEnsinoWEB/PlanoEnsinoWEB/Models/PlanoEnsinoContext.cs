namespace PlanoEnsinoWEB.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PlanoEnsinoContext : DbContext
    {
        public PlanoEnsinoContext()
            : base("name=PlanoEnsinoContext")
        {
        }

        public virtual DbSet<ComponenteCurricular> ComponenteCurriculars { get; set; }
        public virtual DbSet<Curso> Cursoes { get; set; }
        public virtual DbSet<PlanoEnsino> PlanoEnsinoes { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComponenteCurricular>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<ComponenteCurricular>()
                .Property(e => e.objetivo)
                .IsUnicode(false);

            modelBuilder.Entity<ComponenteCurricular>()
                .Property(e => e.modalidade_oferta)
                .IsUnicode(false);

            modelBuilder.Entity<ComponenteCurricular>()
                .Property(e => e.ementa)
                .IsUnicode(false);

            modelBuilder.Entity<ComponenteCurricular>()
                .Property(e => e.referencias_basicas)
                .IsUnicode(false);

            modelBuilder.Entity<ComponenteCurricular>()
                .Property(e => e.referencias_complementares)
                .IsUnicode(false);

            modelBuilder.Entity<ComponenteCurricular>()
                .HasMany(e => e.PlanoEnsinoes)
                .WithRequired(e => e.ComponenteCurricular)
                .HasForeignKey(e => e.codigo_componente_curricular)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Curso>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .Property(e => e.objetivo)
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.ComponenteCurriculars)
                .WithRequired(e => e.Curso)
                .HasForeignKey(e => e.codigo_curso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanoEnsino>()
                .Property(e => e.colegiado)
                .IsUnicode(false);

            modelBuilder.Entity<PlanoEnsino>()
                .Property(e => e.possibilidade_integracao)
                .IsUnicode(false);

            modelBuilder.Entity<PlanoEnsino>()
                .Property(e => e.avaliacao_curricular)
                .IsUnicode(false);

            modelBuilder.Entity<PlanoEnsino>()
                .Property(e => e.referencias_aprofundamento)
                .IsUnicode(false);

            modelBuilder.Entity<PlanoEnsino>()
                .Property(e => e.conteudo_programado)
                .IsUnicode(false);

            modelBuilder.Entity<PlanoEnsino>()
                .Property(e => e.cronograma)
                .IsUnicode(false);

            modelBuilder.Entity<PlanoEnsino>()
                .Property(e => e.estrategia_recuperacao)
                .IsUnicode(false);

            modelBuilder.Entity<PlanoEnsino>()
                .Property(e => e.metodologia)
                .IsUnicode(false);

            modelBuilder.Entity<PlanoEnsino>()
                .Property(e => e.professores)
                .IsUnicode(false);

            modelBuilder.Entity<PlanoEnsino>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Professor>()
                .Property(e => e.nome)
                .IsUnicode(false);
        }
    }
}
