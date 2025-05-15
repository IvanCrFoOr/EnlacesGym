using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class InventorySold : BaseEntity
    {
        public int UsuarioId { get; set; }
        public int CatInventorySuplementsId { get; set; }
        public DateTime DateSell { get; set; }
        public decimal PriceSell { get; set; }


        [Required]
        public virtual Usuario Usuario { get; set; }
        [Required]
        public virtual CatInventorySuplements CatInventorySuplements { get; set; }
    }
}
