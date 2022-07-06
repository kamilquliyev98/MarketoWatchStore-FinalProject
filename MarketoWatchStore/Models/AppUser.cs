using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(255)]
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(255)]
        public string Country { get; set; }
        [StringLength(255)]
        public string City { get; set; }
        [StringLength(255)]
        public string ZipCode { get; set; }
        public string EmailConfirmationToken { get; set; }
        public string PasswordResetToken { get; set; }

        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<CompareList> CompareLists { get; set; }
        public IEnumerable<Wishlist> Wishlists { get; set; }
    }
}
