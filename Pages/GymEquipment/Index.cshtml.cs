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
    public class IndexModel : PageModel
    {
        private readonly FitnessProgram.Models.FPContext _context;

        public IndexModel(FitnessProgram.Models.FPContext context)
        {
            _context = context;
        }

        public IList<Equipment> Equipment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Equipment = await _context.Equipment.ToListAsync();
        }
    }
}
