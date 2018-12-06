namespace PlanoEnsinoWEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Curso")]
    public partial class Curso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Curso()
        {
            ComponenteCurriculars = new HashSet<ComponenteCurricular>();
        }

        [Display(Name = "ID Curso")]
        [Key]
        public int IdCurso { get; set; }
       
        [Required]
        [StringLength(250)]
        [Display(Name = "Curso")]
        public string nome { get; set; }

        [Required]
        [Display(Name = "Objetivo do Curso")]
        public string objetivo { get; set; }

        //public List<Curso> Cursos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComponenteCurricular> ComponenteCurriculars { get; set; }
    }
}
