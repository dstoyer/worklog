using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Worklog.Models;

namespace Worklog.Pages.Worklogs
{
    public class CreateModel : PageModel
    {
        private readonly Worklog.Models.WorklogContext _context;

        public CreateModel(Worklog.Models.WorklogContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ProjectID"] = new SelectList(_context.Set<Project>(), "ProjectID", "ProjectName");
        ViewData["WorkTaskID"] = new SelectList(_context.Set<WorkTask>(), "WorkTaskID", "TaskName");
            return Page();
        }

        [BindProperty]
        public Log Log { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Log.Add(Log);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}