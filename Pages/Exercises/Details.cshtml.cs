using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessProgram.Models;

namespace FitnessProgram.Pages.Exercises
{
    public class DetailsModel : PageModel
    {
        private readonly FitnessProgram.Models.FPContext _context;

        public DetailsModel(FitnessProgram.Models.FPContext context)
        {
            _context = context;
        }

        public Exercise Exercise { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercises.FirstOrDefaultAsync(m => m.ExerciseId == id);

            if (exercise is not null)
            {
                Exercise = exercise;

                return Page();
            }

            return NotFound();
        }
    }
}
