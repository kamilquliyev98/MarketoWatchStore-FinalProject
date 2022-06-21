using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Models
{
    public class ServicePolicy : BaseEntity
    {
        [StringLength(1000)]
        public string Image { get; set; }
        [StringLength(255), Required]
        public string Title { get; set; }
        [StringLength(255), Required]
        public string Description { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
