using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Names { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public int RolId { get; set; }

        [Required]
        public virtual Rol Rol { get; set; }
    }
}
