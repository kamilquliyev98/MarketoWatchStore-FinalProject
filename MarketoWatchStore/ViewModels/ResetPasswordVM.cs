﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketoWatchStore.ViewModels
{
    public class ResetPasswordVM
    {
        public string Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Token { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(nameof(Password)), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
