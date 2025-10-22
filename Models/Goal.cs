using System;
using System.Collections.Generic;

namespace FitnessProgram.Models;

public partial class Goal
{
    public int GoalId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public int Status { get; set; }

    public int CategoryId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual AppUser User { get; set; } = null!;
}
