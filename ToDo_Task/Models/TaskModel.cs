using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo_Task.Models
{
    public class TaskModel
    {
        //private TaskContext context;

        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public double percentage_complete { get; set; }
        public DateTime expiredAt { get; set; }
    }
}
