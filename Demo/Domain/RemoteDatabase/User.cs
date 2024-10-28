﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.RemoteDatabase
{
    public class User
    {
        public required string FIO { get; set; }
        public Guid Guid { get; set; }

        public required Group Group { get; set; }
    }
}