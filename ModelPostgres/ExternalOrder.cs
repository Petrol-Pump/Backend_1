using System;
using System.Collections.Generic;

namespace Petrol_Pump1.ModelPostgres;

public partial class ExternalOrder
{
    public decimal ExtOrderid { get; set; }

    public string? BuyerName { get; set; }

    public decimal? OverseenBy { get; set; }

    public int? ProductBought { get; set; }

    public decimal? TotalPayable { get; set; }

    public decimal? UnitsBought { get; set; }

    public string? BuyerPhone { get; set; }

    public DateOnly? DateOrdered { get; set; }

    public virtual Employee? OverseenByNavigation { get; set; }

    public virtual Product? ProductBoughtNavigation { get; set; }
}
