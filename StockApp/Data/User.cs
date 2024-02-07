using System;
using System.Collections.Generic;

namespace StockApp.Data;

public partial class User
{
    public Guid UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Watchlist> Watchlists { get; set; } = new List<Watchlist>();
}
