using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Worklog.Models;

namespace Worklog.Pages.Tasks
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
            return Page();
        }

        [BindProperty]
        public WorkTask WorkTask { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
			bool contains = _context.WorkTask.AsEnumerable().Any(row => WorkTask.TaskName.Equals(row.TaskName));
			if (!contains)
			{
				_context.WorkTask.Add(WorkTask);
				await _context.SaveChangesAsync();
			}

            return RedirectToPage("./Index");
        }
    }
}