﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.ViewModels.Problems
{
    public class SubmissionViewModel
    {
        public string SubmissionId { get; set; }
        public string Username { get; set; }
        public int AchievedResult { get; set; }
        public int MaxPoints { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Percentage => (int)Math.Round(this.AchievedResult * 100.0M / this.MaxPoints);
    }
}
