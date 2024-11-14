using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.domain.Models
{
    public class PresenceLocalEntity
    {
        public Guid UserGuid { get; set; } 
        public int GroupId { get; set; }
        public int LessonNumber { get; set; }
        public DateTime Date { get; set; }
        public bool IsAttedance { get; set; }
    }
}
