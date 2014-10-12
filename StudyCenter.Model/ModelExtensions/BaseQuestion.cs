using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCenter.Model
{
    public class BaseQuestion
    {
        public int ID { get; set; }
        public short IsDeleted { get; set; }
        public string Remark { get; set; }
        public DateTime? SubTime { get; set; }
        public string Content { get; set; }
        public string Answers { get; set; }
        public bool? IsPublic { get; set; }
        public short? Difficulty { get; set; }
        public virtual User Publisher { get; set; }
        public virtual Course CourseTo { get; set; }
    }


}
