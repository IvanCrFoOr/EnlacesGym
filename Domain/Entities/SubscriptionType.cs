using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubscriptionType : BaseEntity
    {
        [StringLength(100)]
        public string SubscriptionName { get; set; }
        public int DaysBase {  get; set; }
    }
}
