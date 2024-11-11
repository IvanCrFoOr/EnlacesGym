using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Places.Commands
{
    public class PhotosViewModel
    {
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
