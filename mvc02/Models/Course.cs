using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace mvc02.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "cannot be Empty")]
        public string Code { get; set; }

        [Display(Name="Course Name")]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Tutor { get; set; }

        [DisplayFormat(DataFormatString="{0:C}")]
        public decimal Price { get; set; }
    }
}
