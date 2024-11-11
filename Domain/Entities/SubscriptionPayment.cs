using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubscriptionPayment : BaseEntity
    {
        public int SubscriptionType {  get; set; }
        public int UsuarioId { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime? DateDue {  get; set; }

        [Required]
        public virtual Usuario Usuario { get; set; }
    }
}
