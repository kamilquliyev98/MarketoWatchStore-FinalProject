using MarketoWatchStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.ViewModels
{
    public class ShopVM
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
