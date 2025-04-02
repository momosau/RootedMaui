﻿using System;
using System.Collections.Generic;

namespace SharedLibraryy.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public double Amount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime PaymentDate { get; set; }

    public int OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;
}
