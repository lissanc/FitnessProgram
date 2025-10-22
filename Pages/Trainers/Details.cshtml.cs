using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessProgram.Models;

namespace FitnessProgram.Pages.Trainers
{
    public class DetailsModel : PageModel
    {
        private readonly FitnessProgram.Models.FPContext _context;

        public DetailsModel(FitnessProgram.Models.FPContext context)
        {
            _context = context;
        }

        public Trainer Trainer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainer = await _context.Trainers.FirstOrDefaultAsync(m => m.UserId == id);

            if (trainer is not null)
            {
                Trainer = trainer;

                return Page();
            }

            return NotFound();
        }
    }
}
