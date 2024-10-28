using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.ModesDAO
{
    public class GroupDAO
    {
        public int Id { get; set;  }
        public required string Name { get; set; }
        public IEnumerable<UserDAO> Users { get; set; }
    }
}
