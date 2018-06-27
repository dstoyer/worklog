using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Worklog.Models;

namespace Worklog.Pages.Worklogs
{
    public class DetailsModel : PageModel
    {
        private readonly Worklog.Models.WorklogContext _context;

        public DetailsModel(Worklog.Models.WorklogContext context)
        {
            _context = context;
        }

        public Log Log { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Log = await _context.Log
                .Include(l => l.Project)
                .Include(l => l.WorkTask).FirstOrDefaultAsync(m => m.LogID == id);

            if (Log == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
