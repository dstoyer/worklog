using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Worklog.Models;

namespace Worklog.Pages.Tasks
{
    public class EditModel : PageModel
    {
        private readonly Worklog.Models.WorklogContext _context;

        public EditModel(Worklog.Models.WorklogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WorkTask WorkTask { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkTask = await _context.WorkTask.FirstOrDefaultAsync(m => m.WorkTaskID == id);

            if (WorkTask == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WorkTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkTaskExists(WorkTask.WorkTaskID))
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

        private bool WorkTaskExists(int id)
        {
            return _context.WorkTask.Any(e => e.WorkTaskID == id);
        }
    }
}
