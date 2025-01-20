using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yogagym.Models;

public partial class Member
{
    public decimal Memberid { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string? Imagepath { get; set; }


    [NotMapped]
    public virtual IFormFile ImageFile { get; set; }


    public string? Email { get; set; }

    public virtual ICollection<Creditcarddetail> Creditcarddetails { get; set; } = new List<Creditcarddetail>();

    public virtual ICollection<MembersSubscription> MembersSubscriptions { get; set; } = new List<MembersSubscription>();

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public virtual ICollection<Testimonial> Testimonials { get; set; } = new List<Testimonial>();

    public virtual ICollection<Userlogin> Userlogins { get; set; } = new List<Userlogin>();
}
