using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.ModesDAO
{
    public class PresenceDAO
    {
        public Guid userGuid {  get; set; }
        public bool IsAttedance { get; set; }
        public DateOnly Date {  get; set; }
        public int LessonNumber { get; set; }
        public UserDAO UserDAO { get; set; }
    }
}
