﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AboCafes.Common.Requests
{
   public class EmailRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

    }
}
