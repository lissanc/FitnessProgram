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
    public class DetailsModel : PageModel
    {
        private readonly FitnessProgram.Models.FPContext _context;

        public DetailsModel(FitnessProgram.Models.FPContext context)
        {
            _context = context;
        }

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
    }
}
