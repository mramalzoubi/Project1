using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yogagym.Models;

public partial class Header
{
    public decimal Id { get; set; }

    public string? Imagepath { get; set; }

    [NotMapped]
    public virtual IFormFile ImageFile { get; set; }

}
