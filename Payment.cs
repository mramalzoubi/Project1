using System;
using System.Collections.Generic;

namespace Yogagym.Models;

public partial class Payment
{
    public decimal Paymentid { get; set; }

    public decimal Subscriptionid { get; set; }

    public decimal Amount { get; set; }

    public DateTime Paymentdate { get; set; }

    public decimal? Cardid { get; set; }

    public virtual Creditcarddetail? Card { get; set; }

    public virtual Subscription Subscription { get; set; } = null!;
}
