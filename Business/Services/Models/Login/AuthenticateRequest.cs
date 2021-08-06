﻿using System.ComponentModel.DataAnnotations;

namespace Business.Services.Models.Login
{
    public class AuthenticateRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
