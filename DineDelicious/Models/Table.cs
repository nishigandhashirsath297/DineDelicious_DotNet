using System;
using System.Collections.Generic;

namespace DineDelicious.Models;

public partial class Table
{
    public int Id { get; set; }

    public int TableNumber { get; set; }

    public int? Size { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
