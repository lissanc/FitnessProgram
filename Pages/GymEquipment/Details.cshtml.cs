using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FitnessProgram.Models;

namespace FitnessProgram.Pages.GymEquipment
{
    public class DetailsModel : PageModel
    {
        private readonly FitnessProgram.Models.FPContext _context;

        public DetailsModel(FitnessProgram.Models.FPContext context)
        {
            _context = context;
        }

        public Equipment Equipment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment.FirstOrDefaultAsync(m => m.EquipId == id);

            if (equipment is not null)
            {
                Equipment = equipment;

                return Page();
            }

            return NotFound();
        }
    }
}
