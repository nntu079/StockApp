using System;
using System.Collections.Generic;

namespace StockApp.Data;

public partial class IndustryStock
{
    public Guid IndustryId { get; set; }

    public Guid StockId { get; set; }

    public virtual Industry Industry { get; set; } = null!;

    public virtual Stock Stock { get; set; } = null!;
}
