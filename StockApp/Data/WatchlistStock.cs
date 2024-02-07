using System;
using System.Collections.Generic;

namespace StockApp.Data;

public partial class WatchlistStock
{
    public Guid WatchlistId { get; set; }

    public Guid StockId { get; set; }

    public virtual Stock Stock { get; set; } = null!;

    public virtual Watchlist Watchlist { get; set; } = null!;
}
