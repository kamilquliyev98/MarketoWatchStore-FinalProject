using MarketoWatchStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<ProductColour> ProductColours { get; set; }
    }
}
