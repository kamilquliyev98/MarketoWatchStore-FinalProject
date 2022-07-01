using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.ViewModels
{
    public class CompareListVM
    {
        public int ProductId { get; set; }

        public string Title { get; set; }
        public string MainImage { get; set; }
        public double Price { get; set; }
    }
}
