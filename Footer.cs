using System;
using System.Collections.Generic;

namespace Yogagym.Models;

public partial class Footer
{
    public decimal Id { get; set; }

    public string Location { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Copyright { get; set; }

    public string? Linkinstagram { get; set; }

    public string? Linkfacebook { get; set; }

    public string? Linkx { get; set; }
}
