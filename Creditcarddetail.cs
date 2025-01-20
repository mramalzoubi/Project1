using System;
using System.Collections.Generic;

namespace Yogagym.Models;

public partial class Creditcarddetail
{
    public decimal Cardid { get; set; }

    public decimal Memberid { get; set; }

    public string Cardnumber { get; set; } = null!;

    public DateTime Expirydate { get; set; }

    public string? Cvv { get; set; }

    public decimal Availablebalance { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
