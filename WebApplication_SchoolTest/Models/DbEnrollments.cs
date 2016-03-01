using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_SchoolTest.Models
{
    public class DbEnrollments
    {
        public int EnrollmentID { get; set; }
        public Course _Course { get; set; }
        public Student _Student { get; set; }
        public Grade? Grade { get; set; }
    }
}