using System;
using System.Collections.Generic;

namespace LeasingOfferBack.Entities;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
