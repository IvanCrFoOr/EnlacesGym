using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubscriptionUser : BaseEntity
    {
        public DateTime? subscriptionDate { get; set; }
        public int UsuarioId { get; set; }
        public int SubscriptionTypeId { get; set; }


        [Required]
        public virtual Usuario Usuario { get; set; }
        [Required]
        public virtual SubscriptionType SubscriptionType { get; set; }
    }
}
