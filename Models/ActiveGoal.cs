using System;
using System.Collections.Generic;

namespace FitnessProgram.Models;

public partial class ActiveGoal
{
    public int GoalId { get; set; }

    public string Name { get; set; } = null!;

    public int UserId { get; set; }

    public int Status { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
}
