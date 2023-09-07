using System;
using System.Collections.Generic;

namespace Petrol_Pump1.ModelPostgres;

public partial class Contractor
{
    public int ContractorId { get; set; }

    public string Name { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string LoginPassword { get; set; } = null!;

    public virtual ICollection<InternalOrder> InternalOrders { get; set; } = new List<InternalOrder>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
