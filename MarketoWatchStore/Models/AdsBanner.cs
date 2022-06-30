using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Models
{
    public class AdsBanner : BaseEntity
    {
        [StringLength(1000)]
        public string Image { get; set; }
        [StringLength(80), Required]
        public string Title { get; set; }
        [StringLength(255), Required]
        public string Text { get; set; }
        public bool IsShared { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
