namespace PlanoEnsinoWEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComponenteCurricular")]
    public partial class ComponenteCurricular
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ComponenteCurricular()
        {
            PlanoEnsinoes = new HashSet<PlanoEnsino>();
        }

        [Key]
        [Display(Name = "ID Componente Curricular")]
        public int IdComponenteCurricular { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Componente Curricular")]
        public string nome { get; set; }

        [Display(Name = "Semestre")]
        public int semestre { get; set; }

        [Required]
        [Display(Name = "Objetivo")]
        public string objetivo { get; set; }

        [Required]
        [Display(Name = "Modalidade de Oferta")]
        public string modalidade_oferta { get; set; }

        [Required]
        [Display(Name = "Ementa")]
        public string ementa { get; set; }

        [Required]
        [Display(Name = "Ref�rencias B�sicas")]
        public string referencias_basicas { get; set; }

        [Display(Name = "Ref�rencias Complementares")]
        public string referencias_complementares { get; set; }

        [Display(Name = "Horas Aula � Dist�ncia")]
        public int hora_aula_distancia { get; set; }

        [Display(Name = "Horas Aula Presencial")]
        public int hora_aula_presencial { get; set; }

        [Display(Name = "Hora Rel�gio � Dist�ncia")]
        public int hora_relogio_distancia { get; set; }

        [Display(Name = "Hora Rel�gio Presencial")]
        public int hora_relogio_presencial { get; set; }

        [Display(Name = "ID Curso")]
        public int codigo_curso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanoEnsino> PlanoEnsinoes { get; set; }

        public virtual Curso Curso { get; set; }
    }
}
