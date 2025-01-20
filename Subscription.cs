using System;
using System.Collections.Generic;

namespace Yogagym.Models;

public partial class Subscription
{
    public decimal Subscriptionid { get; set; }

    public decimal Memberid { get; set; }

    public decimal Planid { get; set; }

    public DateTime Startdate { get; set; }

    public DateTime? Enddate { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<MembersSubscription> MembersSubscriptions { get; set; } = new List<MembersSubscription>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Workoutplan Plan { get; set; } = null!;
}
