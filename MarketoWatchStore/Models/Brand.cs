using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Models
{
    public class Brand : BaseEntity
    {
        [StringLength(255), Required]
        public string Title { get; set; }
        [StringLength(1000)]
        public string Logo { get; set; }
        [StringLength(1000)]
        public string Website { get; set; }
        public bool IsShared { get; set; }
    }
}
