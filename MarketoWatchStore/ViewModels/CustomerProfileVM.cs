using MarketoWatchStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.ViewModels
{
    public class CustomerProfileVM
    {
        public CustomerUpdateVM Customer { get; set; }
        public List<Order> Orders { get; set; }
    }
}
