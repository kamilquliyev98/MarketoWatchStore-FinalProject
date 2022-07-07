using MarketoWatchStore.Enums;
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
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Colour> Colours { get; set; }
        public IEnumerable<GenderType> Genders { get; set; }
        public IEnumerable<Feature> Features { get; set; }
        public IEnumerable<PowerSource> PowerSources { get; set; }
        public IEnumerable<AdsBanner> AdsBanners { get; set; }

        public Product Product { get; set; }
        public ProductVM ProductVM { get; set; }
    }
}
