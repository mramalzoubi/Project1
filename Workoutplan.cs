using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yogagym.Models;

public partial class Workoutplan
{
    public decimal Planid { get; set; }

    public string Planname { get; set; } = null!;

    public decimal? Duration { get; set; }

    public decimal Trainerid { get; set; }

    public decimal? Price { get; set; }

    public string? Imagepath { get; set; }

    [NotMapped]
    public virtual IFormFile? ImageFile { get; set; }


    public virtual ICollection<MembersSubscription> MembersSubscriptions { get; set; } = new List<MembersSubscription>();

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public virtual Trainer Trainer { get; set; } = null!;

}
