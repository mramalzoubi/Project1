using System;
using System.Collections.Generic;

namespace Yogagym.Models;

public partial class Userlogin
{
    public decimal Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public decimal Roleid { get; set; }

    public decimal? Memberid { get; set; }

    public decimal? Trainerid { get; set; }

    public decimal? Adminid { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual Member? Member { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual Trainer? Trainer { get; set; }
}
