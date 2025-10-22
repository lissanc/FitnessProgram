using System;
using System.Collections.Generic;

namespace FitnessProgram.Models;

public partial class Trainer
{
    public int TrainerId { get; set; }

    public int UserId { get; set; }

    public string? Certification { get; set; }

    public string? Specialization { get; set; }

    public int? YearsExperience { get; set; }

    public string? Name { get; set; }


    public virtual ICollection<FitnessPlan> FitnessPlans { get; set; } = new List<FitnessPlan>();

    public virtual AppUser User { get; set; } = null!;
    
    public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
}
