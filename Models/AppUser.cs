using System;
using System.Collections.Generic;

namespace FitnessProgram.Models;

public partial class AppUser
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public int FitnessLevel { get; set; }

    public virtual ICollection<FitnessPlan> FitnessPlans { get; set; } = new List<FitnessPlan>();

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    public virtual ICollection<Trainer> Trainers { get; set; } = new List<Trainer>();

    public virtual ICollection<Trainer> TrainerTrainers { get; set; } = new List<Trainer>();
}
