using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CatInventorySuplements : BaseEntity
    {
        public string NameSuplement { get; set; }
        public int Cuantity { get; set; }
        public decimal PricePublic { get; set; }
        public bool Active { get; set; }
    }
}
