﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    [Display(Name = "Imię i Nazwisko")]
    public string FullName { get; set; }
}
