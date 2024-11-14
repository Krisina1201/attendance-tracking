﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.ModesDAO
{
    public class PresenceDAO
    {
        public int Id { get; set; }
        public Guid UserGuid { get; set; }
        public bool IsAttedance { get; set; } = true;
        public DateOnly Date { get; set; }
        public int LessonNumber { get; set; }
        public virtual UserDAO? UserDao { get; set; }
    }
}
