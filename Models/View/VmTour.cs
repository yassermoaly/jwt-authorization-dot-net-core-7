using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.View
{
    public class VmTour
    {
        public int id { get; set; }
        public string? title { get; set; }
        public int price { get; set; }
        public string? currency { get; set; }
        public double rating { get; set; }
        public bool isSpecialOffer { get; set; }
    }
}
