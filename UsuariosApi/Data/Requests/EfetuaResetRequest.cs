﻿using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Requests
{
    public class EfetuaResetRequest
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
