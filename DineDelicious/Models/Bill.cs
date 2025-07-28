using System;
using System.Collections.Generic;

namespace DineDelicious.Models;

public partial class Bill
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime? GeneratedAt { get; set; }

    public string? PaymentMethod { get; set; }
    
    public virtual Order Order { get; set; } = null!;
}
