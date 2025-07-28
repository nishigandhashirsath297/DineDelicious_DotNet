using System;
using System.Collections.Generic;

namespace DineDelicious.Models;

public partial class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int MenuItemId { get; set; }

    public int Quantity { get; set; }

    public virtual MenuItem MenuItem { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
