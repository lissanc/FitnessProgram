using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessProgram.Models;

namespace FitnessProgram.Pages.FitnessPlans
{
    public class DeleteModel : PageModel
    {
        private readonly FitnessProgram.Models.FPContext _context;

        public DeleteModel(FitnessProgram.Models.FPContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FitnessPlan FitnessPlan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessplan = await _context.FitnessPlans.FirstOrDefaultAsync(m => m.PlanId == id);

            if (fitnessplan is not null)
            {
                FitnessPlan = fitnessplan;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fitnessplan = await _context.FitnessPlans.FindAsync(id);
            if (fitnessplan != null)
            {
                FitnessPlan = fitnessplan;
                _context.FitnessPlans.Remove(FitnessPlan);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
