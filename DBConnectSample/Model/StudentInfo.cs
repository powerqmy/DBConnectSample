using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectSample.Model
{
    public class StudentInfo
    {
        [Key]
        public int StudentNo { get; set; }
        [ForeignKey("StudentNo")]
        public virtual Student Student { get; set; }

        [StringLength(32)]
        [Required]
        public string Father { get; set; }

        
    }
}
