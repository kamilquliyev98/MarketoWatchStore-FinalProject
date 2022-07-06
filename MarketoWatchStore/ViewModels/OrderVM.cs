using MarketoWatchStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.ViewModels
{
    public class OrderVM
    {
        [StringLength(255), Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(255), Required]
        public string FullName { get; set; }
        [StringLength(255), Required]
        public string Address { get; set; }
        [StringLength(255), Required]
        public string Country { get; set; }
        [StringLength(255), Required]
        public string City { get; set; }
        [StringLength(255), Required]
        public string ZipCode { get; set; }
        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
    }
}
