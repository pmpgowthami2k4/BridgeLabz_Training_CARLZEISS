using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.DTOs
{
    public class ResetPasswordDto
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
