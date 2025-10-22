using System;
using System.Collections.Generic;

namespace FitnessProgram.Models;

public partial class FitnessPlan
{
    public int PlanId { get; set; }

    public int TrainerId { get; set; }

    public int UserId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public int DurationWeeks { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Trainer Trainer { get; set; } = null!;

    public virtual AppUser User { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
