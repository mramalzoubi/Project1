using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yogagym.Models;

public partial class Trainer
{
    public decimal Trainerid { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string? Imagepath { get; set; }


    [NotMapped]
    public virtual IFormFile ImageFile { get; set; }


    public string? Email { get; set; }

    [NotMapped]
    public string? Username { get; set; }

    [NotMapped]
    public string? Password { get; set; }


    public virtual ICollection<Userlogin> Userlogins { get; set; } = new List<Userlogin>();

    public virtual ICollection<Workoutplan> Workoutplans { get; set; } = new List<Workoutplan>();
}
