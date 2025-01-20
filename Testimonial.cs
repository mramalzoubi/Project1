using System;
using System.Collections.Generic;

namespace Yogagym.Models;

public partial class Testimonial
{
    public decimal Testimonialid { get; set; }

    public decimal Memberid { get; set; }

    public string Testimonialtext { get; set; } = null!;

    public string? Status { get; set; }

    public decimal? Reviewedby { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual Admin? ReviewedbyNavigation { get; set; }
}
