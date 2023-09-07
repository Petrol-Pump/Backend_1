using System;
using System.Collections.Generic;

namespace Petrol_Pump1.ModelPostgres;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductDescription { get; set; } = null!;

    public decimal UnitsInStock { get; set; }

    public decimal PricePerUnit { get; set; }

    public int? SuppliedBy { get; set; }

    public decimal? ThresholdUnits { get; set; }

    public virtual ICollection<ExternalOrder> ExternalOrders { get; set; } = new List<ExternalOrder>();

    public virtual ICollection<InternalOrder> InternalOrders { get; set; } = new List<InternalOrder>();

    public virtual Contractor? SuppliedByNavigation { get; set; }
}
