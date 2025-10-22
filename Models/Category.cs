using System;
using System.Collections.Generic;

namespace FitnessProgram.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();

    public virtual ICollection<FitnessPlan> FitnessPlans { get; set; } = new List<FitnessPlan>();

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();
}
