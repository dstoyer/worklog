using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Worklog.Models
{
	public class Log
	{
		public Log() { }

		public Log(
			int logID,
			int projectID,
			int workTaskID,
			DateTime logDate,
			double timeSpent,
			string title,
			string description
		) {
			LogID = logID;
			ProjectID = ProjectID;
			WorkTaskID = workTaskID;
			LogDate = logDate;
			TimeSpent = timeSpent;
			Title = title;
			Description = description;
		}


		public int LogID { get; set; }

		[Display(Name = "Project Name")]
		public int ProjectID { get; set; }

		[Display(Name = "Task Name")]
		public int WorkTaskID { get; set; }

		[Display(Name = "Date")]
		[Required, DataType(DataType.Date)]
		public DateTime LogDate { get; set; }

		[Display(Name = "Time")]
		public double TimeSpent { get; set; }

		[Display(Name = "Title/Summary")]
		[Required, StringLength(60, MinimumLength = 3)]
		public string Title { get; set; }

		[StringLength(1200, MinimumLength = 0)]
		public string Description { get; set; }

		public Project Project { get; set; }

		[Display(Name = "Task")]
		public WorkTask WorkTask { get; set; }
    }
}
