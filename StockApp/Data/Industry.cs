using System;
using System.Collections.Generic;

namespace StockApp.Data;

public partial class Industry
{
    public Guid IndustryId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
}
