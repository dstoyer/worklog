﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Worklog.Models
{
    public class Project
    {
		public int ProjectID { get; set; }

		[StringLength(60, MinimumLength = 3), Required]
		public string ProjectName { get; set; }

		ICollection<Log> Worklogs { get; set; }
    }
}
