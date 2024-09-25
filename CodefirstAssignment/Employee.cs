using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodefirstAssignment
{
    [Table("emptbl")]
    public class Employee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        [RegularExpression(@"(E/d[3])", ErrorMessage = "EmpID should start with E following 3 digits")]
        public string Empid { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]

        public string EmpName { get; set; }
        
        public virtual Department Deptid { get; set; }

        [Range(50000,150000, ErrorMessage = "Salary should be between 50000 and 150000")]
        public int Salary { get; set; }

        public DateTime DOB { get; set; }


    }
}
