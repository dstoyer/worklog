using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Worklog.Models
{
    public class Project
    {
		public int ProjectID { get; set; }

		[Display(Name = "Project Name")]
		[StringLength(60, MinimumLength = 3), Required]
		public string ProjectName { get; set; }

		ICollection<Log> Worklog { get; set; }
    }
}
