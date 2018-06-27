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
    public class IndexModel : PageModel
    {
        private readonly Worklog.Models.WorklogContext _context;

        public IndexModel(Worklog.Models.WorklogContext context)
        {
            _context = context;
        }

        public IList<Log> Log { get;set; }

        public async Task OnGetAsync()
        {
            Log = await _context.Log
                .Include(l => l.Project)
                .Include(l => l.WorkTask).ToListAsync();
        }
    }
}
