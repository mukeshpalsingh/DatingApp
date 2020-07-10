using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Api.Dtos
{
    public class UserForLoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Must be at least 4 characters long.")]
        public string Password { get; set; }
    }
}
