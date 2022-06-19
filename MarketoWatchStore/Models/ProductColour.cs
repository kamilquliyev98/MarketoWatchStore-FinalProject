using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Models
{
    public class ProductColour
    {
        public int Id { get; set; }

        public Nullable<int> ProductId { get; set; }
        public Product Product { get; set; }

        public Nullable<int> ColourId { get; set; }
        public Colour Colour { get; set; }
    }
}
