using MarketoWatchStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Product> Slides { get; set; }
        public Setting Setting { get; set; }
        public IEnumerable<ServicePolicy> ServicePolicies { get; set; }
        public IEnumerable<Product> Posters { get; set; }
        public IEnumerable<Product> NewArrival { get; set; }
        public IEnumerable<SpecialType> SpecialTypes { get; set; }
        public IEnumerable<Product> LatestProducts { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}
