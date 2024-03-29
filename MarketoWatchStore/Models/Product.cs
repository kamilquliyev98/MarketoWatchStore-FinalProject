﻿using MarketoWatchStore.Enums;
using Microsoft.AspNetCore.Http;
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
        [StringLength(1000)]
        public string SlideImage { get; set; }
        public bool ShareOnHomeSlide { get; set; }
        [StringLength(1000)]
        public string PosterImage { get; set; }
        public bool ShareAsPoster { get; set; }
        [Column(TypeName = "money"), Required]
        public double Price { get; set; }
        [Column(TypeName = "money")]
        public Nullable<double> DiscountPrice { get; set; }
        [Column(TypeName = "money"), Required]
        public double ExTax { get; set; }
        public int Count { get; set; }
        [StringLength(1000), Required]
        public string Description { get; set; }
        public bool IsNewArrival { get; set; }
        public GenderType Gender { get; set; }

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

        [NotMapped]
        public IFormFile MainImageFile { get; set; }
        [NotMapped]
        public IFormFile[] ProductImagesFiles { get; set; }
        [NotMapped]
        public IFormFile SlideImageFile { get; set; }
        [NotMapped]
        public IFormFile PosterImageFile { get; set; }
        [NotMapped]
        public List<int> FeatureIds { get; set; } = new List<int>();
        [NotMapped]
        public List<int> TagIds { get; set; } = new List<int>();
        [NotMapped]
        public List<int> ColourIds { get; set; } = new List<int>();
        [NotMapped]
        public List<int> Counts { get; set; } = new List<int>();
    }
}
