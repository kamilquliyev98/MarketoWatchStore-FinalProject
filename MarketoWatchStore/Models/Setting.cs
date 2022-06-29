using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.Models
{
    public class Setting : BaseEntity
    {
        [StringLength(1000)]
        public string Logo { get; set; }
        [StringLength(255)]
        public string Offer { get; set; }
        [StringLength(255), Required, DataType(DataType.PhoneNumber)]
        public string SupportPhone { get; set; }
        [StringLength(255)]
        public string SupportText { get; set; }
        [StringLength(255), DataType(DataType.PhoneNumber)]
        public string Phone2 { get; set; }
        [StringLength(255), Required, DataType(DataType.EmailAddress)]
        public string Email1 { get; set; }
        [StringLength(255), DataType(DataType.EmailAddress)]
        public string Email2 { get; set; }
        [StringLength(255), Required]
        public string Address { get; set; }
        [StringLength(1000), DataType(DataType.Url)]
        public string Facebook { get; set; }
        [StringLength(1000), DataType(DataType.Url)]
        public string Instagram { get; set; }
        [StringLength(1000), DataType(DataType.Url)]
        public string Twitter { get; set; }

        [NotMapped]
        public IFormFile LogoImage { get; set; }
    }
}
