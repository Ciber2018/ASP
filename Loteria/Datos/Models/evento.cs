namespace Datos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("loteria.evento")]
    public partial class evento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public evento()
        {
            tarjeta = new HashSet<tarjeta>();
        }

        [Required]
        [StringLength(20)]
        [Display(Name ="Nombre Evento")]
        public string ID { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name ="Fecha")]
        public string fecha { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Hora")]
        public string hora { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tarjeta> tarjeta { get; set; }
    }
}
