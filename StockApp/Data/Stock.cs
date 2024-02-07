using System;
using System.Collections.Generic;

namespace StockApp.Data;

public partial class Stock
{
    public Guid StockId { get; set; }

    public string Symbol { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal Change { get; set; }

    public int Volume { get; set; }

    public string Sector { get; set; } = null!;

    public string Industry { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
