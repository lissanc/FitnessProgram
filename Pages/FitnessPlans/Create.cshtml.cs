using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FitnessProgram.Models;

namespace FitnessProgram.Pages.FitnessPlans
{
    public class CreateModel : PageModel
    {
        private readonly FitnessProgram.Models.FPContext _context;

        public CreateModel(FitnessProgram.Models.FPContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TrainerId"] = new SelectList(_context.Trainers, "UserId", "UserId");
        ViewData["UserId"] = new SelectList(_context.AppUsers, "UserId", "UserId");
            return Page();
        }

        [BindProperty]
        public FitnessPlan FitnessPlan { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FitnessPlans.Add(FitnessPlan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
