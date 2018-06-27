using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
	

namespace Worklog.Models
{
	public class WorkTask
	{
		public int WorkTaskID { get; set; }

		[Display(Name = "Task")]
		[StringLength(60, MinimumLength = 3), Required]
		public string TaskName { get; set; }

		ICollection<Log> Worklogs { get; set; }
	}
}
