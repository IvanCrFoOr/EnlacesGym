using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PlacesPhotos : BaseEntity
    {
        public string RowId { get; set; }
        public DateTime CreateDate { get; set; }
        public string UrlPhoto { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int PlaceId { get; set; }

        [JsonIgnore]
        public virtual Place Place { get; set; }
    }
}
