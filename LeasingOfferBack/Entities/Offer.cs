using System;
using System.Collections.Generic;

namespace LeasingOfferBack.Entities;

public partial class Offer
{
    public int Id { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int SupplierId { get; set; }

    public DateTime RegisteredAt { get; set; }

    public virtual Supplier Supplier { get; set; } = null!;
}
