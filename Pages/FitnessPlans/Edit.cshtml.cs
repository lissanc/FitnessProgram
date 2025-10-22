using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessProgram.Models;

namespace FitnessProgram.Pages.FitnessPlans
{
    public class EditModel : PageModel
    {
        private readonly FitnessProgram.Models.FPContext _context;

        public EditModel(FitnessProgram.Models.FPContext context)
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

            var fitnessplan =  await _context.FitnessPlans.FirstOrDefaultAsync(m => m.PlanId == id);
            if (fitnessplan == null)
            {
                return NotFound();
            }
            FitnessPlan = fitnessplan;
           ViewData["TrainerId"] = new SelectList(_context.Trainers, "UserId", "UserId");
           ViewData["UserId"] = new SelectList(_context.AppUsers, "UserId", "UserId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FitnessPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FitnessPlanExists(FitnessPlan.PlanId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FitnessPlanExists(int id)
        {
            return _context.FitnessPlans.Any(e => e.PlanId == id);
        }
    }
}
