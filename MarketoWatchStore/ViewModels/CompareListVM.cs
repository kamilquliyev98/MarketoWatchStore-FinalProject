using MarketoWatchStore.Enums;
using MarketoWatchStore.Models;
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
        public GenderType Gender { get; set; }
        public string Brand { get; set; }
        public string Display { get; set; }
        public string PowerSource { get; set; }
        public string SpecialType { get; set; }
        public IEnumerable<Feature> Features { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
