using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Worklog.Models;

namespace Worklog.Models
{
    public class WorklogContext : DbContext
    {
        public WorklogContext (DbContextOptions<WorklogContext> options)
            : base(options)
        {
        }

        public DbSet<Worklog.Models.Log> Log { get; set; }

        public DbSet<Worklog.Models.Project> Project { get; set; }

        public DbSet<Worklog.Models.WorkTask> WorkTask { get; set; }
    }
}
