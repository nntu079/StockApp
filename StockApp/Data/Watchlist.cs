using System;
using System.Collections.Generic;

namespace StockApp.Data;

public partial class Watchlist
{
    public Guid WatchlistId { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
