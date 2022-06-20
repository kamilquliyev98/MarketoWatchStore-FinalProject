using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Models
{
    public class Product : BaseEntity
    {
        [StringLength(255), Required]
        public string Title { get; set; }
        [StringLength(1000)]
        public string MainImage { get; set; }
        [Column(TypeName = "money"), Required]
        public double Price { get; set; }
        [Column(TypeName = "money")]
        public double DiscountPrice { get; set; }
        [Column(TypeName = "money")]
        public double ExTax { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        [StringLength(255)]
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
        public IEnumerable<ProductImage> ProductImages { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
