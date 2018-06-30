using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Worklog.Models;

namespace Worklog.Pages.Projects
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
        public Project Project { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


			bool contains = _context.Project.AsEnumerable().Any(row => Project.ProjectName.Equals(row.ProjectName));
			if (!contains)
			{
				_context.Project.Add(Project);
				await _context.SaveChangesAsync();
			}

            return RedirectToPage("./Index");
        }
    }
}