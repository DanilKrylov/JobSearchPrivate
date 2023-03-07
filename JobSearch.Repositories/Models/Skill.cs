﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Repositories.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }

        public string SkillName { get; set; }
    }
}
