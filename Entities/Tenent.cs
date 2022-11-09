using System;
using System.Collections.Generic;

namespace Entities;

public partial class Tenent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Assignment> Assignments { get; } = new List<Assignment>();
}
