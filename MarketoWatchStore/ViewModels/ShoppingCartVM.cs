using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.ViewModels
{
    public class ShoppingCartVM
    {
        public int ProductId { get; set; }
        public int ColourId { get; set; }
        public int Count { get; set; }

        public string Title { get; set; }
        public string MainImage { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
    }
}
