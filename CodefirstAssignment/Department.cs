using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodefirstAssignment
{

    [Table("depttbl")]
    public class Department
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Deptid { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        [RegularExpression(@"(Finance | HR)", ErrorMessage = "Department name should be Finance or HR")]

        public string DepartmentName { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]

        public string Manager { get; set; }
        [Timestamp]
        public byte[] DepartmentEdit { get; set; }


        public virtual ICollection<Employee> Employees { get; set; }
        
    }
}
