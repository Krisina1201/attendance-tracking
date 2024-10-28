﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.ModesDAO
{
    public class UserDAO
    {
        public required string FIO { get; set; }
        public Guid Guid { get; set; }
        public required int GroupID { get; set; }
        public GroupDAO Group { get; set; }
    }
}