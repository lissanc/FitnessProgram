using System;
using System.Collections.Generic;

namespace FitnessProgram.Models;

public partial class Exercise
{
    public int ExerciseId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public int DifficultyLevel { get; set; }

    public string Instructions { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Equipment> Equips { get; set; } = new List<Equipment>();

    public virtual ICollection<MuscleGroup> MuscleGroups { get; set; } = new List<MuscleGroup>();

    public virtual ICollection<FitnessPlan> Plans { get; set; } = new List<FitnessPlan>();
}
