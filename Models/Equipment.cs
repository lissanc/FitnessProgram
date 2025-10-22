using System;
using System.Collections.Generic;

namespace FitnessProgram.Models;

public partial class Equipment
{
    public int EquipId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
