using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectSample.Model
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int StudentNo { get; set; }

        [StringLength(32)]
        public string Name { get; set; }

        public short Sex { get; set; }
    }
}
