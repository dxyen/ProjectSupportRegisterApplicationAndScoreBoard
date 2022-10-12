﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SupportRegister.Data.Models
{
    public class Scoreboard
    {
        public Scoreboard()
        {
            DetailRegisterScoreboards = new HashSet<DetailRegisterScoreboard>();
        }

        public int IdScore { get; set; }
        public string NameScore { get; set; }
        public int? Price { get; set; }

        public ICollection<DetailRegisterScoreboard> DetailRegisterScoreboards { get; set; }
    }
}
