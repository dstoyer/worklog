using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Worklog.Models;

namespace Worklog.Pages.Worklogs
{
    public class EditModel : PageModel
    {
        private readonly Worklog.Models.WorklogContext _context;

        public EditModel(Worklog.Models.WorklogContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["ProjectID"] = new SelectList(_context.Set<Project>(), "ProjectID", "ProjectName");
           ViewData["WorkTaskID"] = new SelectList(_context.Set<WorkTask>(), "WorkTaskID", "TaskName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Log).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogExists(Log.LogID))
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

        private bool LogExists(int id)
        {
            return _context.Log.Any(e => e.LogID == id);
        }
    }
}
