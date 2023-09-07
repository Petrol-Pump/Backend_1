using System;
using System.Collections.Generic;

namespace Petrol_Pump1.ModelPostgres;

public partial class Employee
{
    public decimal EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? EmployeePhone { get; set; }

    public string? EmployeeEmail { get; set; }

    public string? LoginPassword { get; set; }

    public virtual ICollection<ExternalOrder> ExternalOrders { get; set; } = new List<ExternalOrder>();
}
