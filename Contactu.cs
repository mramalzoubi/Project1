﻿using System;
using System.Collections.Generic;

namespace Yogagym.Models;

public partial class Contactu
{
    public decimal Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Message { get; set; } = null!;
}
