using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Models
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string MainImage { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public double ExTax { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool IsForMen { get; set; }
        public bool IsForWomen { get; set; }

        public Nullable<int> BrandId { get; set; }
        public Brand Brand { get; set; }

        public Nullable<int> DisplayId { get; set; }
        public Display Display { get; set; }

        public Nullable<int> PowerSourceId { get; set; }
        public PowerSource PowerSource { get; set; }

        public Nullable<int> SpecialTypeId { get; set; }
        public SpecialType SpecialType { get; set; }

        public IEnumerable<ProductTag> ProductTags { get; set; }
        public IEnumerable<ProductColour> ProductColours { get; set; }
        public IEnumerable<ProductFeature> ProductFeatures { get; set; }
    }
}
