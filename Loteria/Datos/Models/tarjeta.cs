namespace Datos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("loteria.tarjeta")]
    public partial class tarjeta
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Numero de Tarjeta")]
        public int numeroID { get; set; }

        [Column(TypeName = "text")]       
        [StringLength(65535)]
        [Display(Name = "Estado de T")]
        public string estado { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Asignar a Evento")]
        public string ID { get; set; }

        public virtual evento evento { get; set; }

        

        // [NotMapped]
        //public IEnumerable<evento> eventoCollection { get; set; }        

    }
}
