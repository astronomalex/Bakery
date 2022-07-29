﻿using System;

namespace BakeryTestSolution.Data.Models
{
    public class Croissant
    {
        public static TimeSpan ControlPeriod { get; set; } = TimeSpan.FromHours(48);
        public static TimeSpan ExpirationDateHours { get; set; } = TimeSpan.FromHours(96);
    }
}