using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurdAppWithStoredProcedure.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
