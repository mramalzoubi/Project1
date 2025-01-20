using System;
using System.Collections.Generic;

namespace Yogagym.Models;

public partial class MembersSubscription
{
    public decimal MembersSubscriptionsid { get; set; }

    public decimal Planid { get; set; }

    public decimal? Subscriptionid { get; set; }

    public decimal? Memberid { get; set; }

    public virtual Member? Member { get; set; }

    public virtual Workoutplan Plan { get; set; } = null!;

    public virtual Subscription? Subscription { get; set; }
}
