using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Web.Models
{
    public class EnrollmentDateGroupModel
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int StudentCount { get; set; }
    }
}