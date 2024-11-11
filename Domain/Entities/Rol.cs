using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rol : BaseEntity
    {
        public string RolName {  get; set; }
        public bool Active { get; set; }
    }
}
