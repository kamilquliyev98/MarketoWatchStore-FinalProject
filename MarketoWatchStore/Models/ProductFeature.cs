using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Models
{
    public class ProductFeature
    {
        public int Id { get; set; }

        public Nullable<int> ProductId { get; set; }
        public Product Product { get; set; }

        public Nullable<int> FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
