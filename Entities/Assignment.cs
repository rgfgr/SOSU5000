using System;
using System.Collections.Generic;

namespace Entities;

public partial class Assignment
{
    public int Id { get; set; }

    public int? TenentId { get; set; }

    public string Titel { get; set; } = null!;

    public string? SosuId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string? Notes { get; set; }

    public string Description { get; set; } = null!;

    public bool Completed { get; set; }

    public virtual Employee? Sosu { get; set; }

    public virtual Tenent? Tenent { get; set; }
}
