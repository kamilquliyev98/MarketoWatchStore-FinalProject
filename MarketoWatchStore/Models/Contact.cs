using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Models
{
    public class Contact : BaseEntity
    {
        [StringLength(255), Required]
        public string FirstName { get; set; }
        [StringLength(255), Required]
        public string LastName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(1000), Required]
        public string Message { get; set; }
    }
}
