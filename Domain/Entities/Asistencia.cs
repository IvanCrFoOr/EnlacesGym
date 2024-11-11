using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Asistencia : BaseEntity
    {
        public DateTime AsistenciaDate {  get; set; }
        public int UsuarioId { get; set; }

        [Required]
        public virtual Usuario Usuario { get; set; }
    }
}
