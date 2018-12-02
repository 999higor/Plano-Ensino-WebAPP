namespace PlanoEnsinoWEB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Professor")]
    public partial class Professor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdProfessor { get; set; }

        [Required]
        [StringLength(200)]
        public string nome { get; set; }
    }
}
