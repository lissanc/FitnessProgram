using FitnessProgram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitnessProgram.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly FPContext _context;

    public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    public List<Trainer> Trainers { get; set; } = new List<Trainer>();
    public List<AppUser> Users { get; set; } = new List<AppUser>();
    public List<Equipment> Equipment { get; set; } = new List<Equipment>();
    public List<FitnessPlan> Plans { get; set; } = new List<FitnessPlan>();
    public List<Goal> Goals { get; set; } = new List<Goal>();

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        _context = new FPContext();
        
    }

    public void OnGet()
    {

    }
}
