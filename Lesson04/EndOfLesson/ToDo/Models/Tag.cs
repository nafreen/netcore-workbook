using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class Tag
    {
        public int Id { get; set; }

<<<<<<< HEAD
        public String Value { get; set; }
=======
        public string Value { get; set; }
>>>>>>> a3d359a6355c8dda578150dc02f32a18ac09e18f

        public List<ToDo> ToDos { get; set; }
    }
}
