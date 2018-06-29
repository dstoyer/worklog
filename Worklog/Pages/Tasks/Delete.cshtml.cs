using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Worklog.Models;

namespace Worklog.Pages.Tasks
{
    public class DeleteModel : PageModel
    {
        private readonly Worklog.Models.WorklogContext _context;

        public DeleteModel(Worklog.Models.WorklogContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WorkTask = await _context.WorkTask.FindAsync(id);

            if (WorkTask != null)
            {
                _context.WorkTask.Remove(WorkTask);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
