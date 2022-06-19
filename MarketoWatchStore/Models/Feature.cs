using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Models
{
    public class Feature : BaseEntity
    {
        [StringLength(255), Required]
        public string Title { get; set; }
    }
}
