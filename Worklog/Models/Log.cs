using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Worklog.Models
{
    public class Log
    {
		public int LogID { get; set; }
		[Display(Name = "Project Name")]
		public int ProjectID { get; set; }
		[Display(Name = "Task Name")]
		public int WorkTaskID { get; set; }

		[Display(Name = "Date")]
		[Required, DataType(DataType.Date)]
		public DateTime LogDate { get; set; }
		[Display(Name = "Time Spent")]
		public double TimeSpent { get; set; }

		[Display(Name = "Title/Summary")]
		[Required, StringLength(60, MinimumLength = 3)]
		public string Title { get; set; }

		[StringLength(1200, MinimumLength = 0)]
		public string Description { get; set; }

		//ICollection<Project> Projects { get; set; }
		//ICollection<WorkTask> Tasks { get; set; }
		public Project Project { get; set; }

		[Display(Name = "Task")]
		public WorkTask WorkTask { get; set; }
    }
}
