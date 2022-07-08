using MarketoWatchStore.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Models
{
    public class Review : BaseEntity
    {
        [StringLength(255), Required]
        public string Name { get; set; }
        [StringLength(255), Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(1000), Required]
        public string Comment { get; set; }
        [Range(1, 5), Required]
        public int Star { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
