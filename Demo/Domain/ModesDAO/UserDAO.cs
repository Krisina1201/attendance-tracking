using System;
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
        public int GroupID { get; set; }
        public virtual GroupDAO Group { get; set; }
        public virtual IEnumerable<PresenceDAO> Presences { get; set; }
    }
}
