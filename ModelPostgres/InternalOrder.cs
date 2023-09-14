using System;
using System.Collections.Generic;

namespace Petrol_Pump1.ModelPostgres;

public partial class InternalOrder
{
    public decimal IntOrderid { get; set; }

    public int? SuppliedBy { get; set; }

    public int? ProductBought { get; set; }

    public decimal? UnitsBought { get; set; }

    public decimal? TotalPayable { get; set; }

    public bool? OrderConfirmed { get; set; }

    public bool? ProductDelivered { get; set; }

    public bool? OrderDispatched { get; set; }

    public DateOnly? DateOrdered { get; set; }

    public virtual Product? ProductBoughtNavigation { get; set; }

    public virtual Contractor? SuppliedByNavigation { get; set; }

   /* public static implicit operator InternalOrder(InternalOrder v)
    {
        throw new NotImplementedException();
    }*/
}
