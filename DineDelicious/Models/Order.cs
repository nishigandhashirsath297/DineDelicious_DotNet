using System;
using System.Collections.Generic;

namespace DineDelicious.Models;

public partial class Order
{
    public int Id { get; set; }

    public int TableId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Table Table { get; set; } = null!;
}
