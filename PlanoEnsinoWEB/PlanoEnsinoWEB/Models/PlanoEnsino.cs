namespace PlanoEnsinoWEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlanoEnsino")]
    public partial class PlanoEnsino
    {
        [Key]
        [Display(Name = "ID Plano de Ensino")]
        public int IdPlanoEnsino { get; set; }

        [Display(Name = "Ano Letivo")]
        public int ano { get; set; }

        [Display(Name = "Semestre Letivo")]
        public int semestre_letivo { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Colegiado")]
        public string colegiado { get; set; }

        [Required]
        [Display(Name = "Possibilidade de Integração")]
        public string possibilidade_integracao { get; set; }

        [Required]
        [Display(Name = "Avaliação Curricular")]
        public string avaliacao_curricular { get; set; }

        [Display(Name = "Referências para Aprofundamento")]
        public string referencias_aprofundamento { get; set; }

        [Required]
        [Display(Name = "Conteúdo Programado")]
        public string conteudo_programado { get; set; }

        [Required]
        [Display(Name = "Cronograma")]
        public string cronograma { get; set; }

        [Required]
        [Display(Name = "Estratégia de Recuperação")]
        public string estrategia_recuperacao { get; set; }

        [Required]
        [Display(Name = "Metodologia")]
        public string metodologia { get; set; }

        [Display(Name = "ID Componente Curricular")]
        public int codigo_componente_curricular { get; set; }

        [Display(Name = "Professores")]
        public string professores { get; set; }

        [Display(Name = "Nome Plano de Ensino")]
        public string nome { get; set; }

        public virtual ComponenteCurricular ComponenteCurricular { get; set; }
    }
}
