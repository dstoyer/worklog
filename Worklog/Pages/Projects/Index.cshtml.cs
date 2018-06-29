using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Worklog.Models;

namespace Worklog.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly Worklog.Models.WorklogContext _context;

        public IndexModel(Worklog.Models.WorklogContext context)
        {
            _context = context;
        }

        public IList<Project> Project { get;set; }

        public async Task OnGetAsync()
        {
            Project = await _context.Project.ToListAsync();
        }
    }
}
