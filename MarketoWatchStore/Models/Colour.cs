using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Models
{
    public class Colour : BaseEntity
    {
        [StringLength(255), Required]
        public string Title { get; set; }

        public IEnumerable<ProductColour> ProductColours { get; set; }
    }
}
