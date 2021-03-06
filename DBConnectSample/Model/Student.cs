﻿using System;
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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int StudentNo { get; set; }

        [StringLength(32)]
        [Required]
        public string Name { get; set; }

        [Required]
        public short Sex { get; set; }
    }
}
