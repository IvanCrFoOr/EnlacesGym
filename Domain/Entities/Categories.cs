using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Categories : BaseEntity
    {
        public int Identificator { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string PluralName { get; set; }
        public string Icon { get; set; }
        public string IconSufix { get; set; }
        public int PlaceId { get; set; }

        [JsonIgnore]
        public virtual Place Place { get; set; }
    }
}
