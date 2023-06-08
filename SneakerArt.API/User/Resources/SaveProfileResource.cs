﻿using System.ComponentModel.DataAnnotations;
namespace SneakerArt.API.User.Resources;

public class SaveProfileResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }

}