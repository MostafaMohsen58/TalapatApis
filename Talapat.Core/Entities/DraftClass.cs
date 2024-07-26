using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talapat.Core.Entities
{
    public class Employee:BaseEntity
    {
        public String Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

    }

    public class Department : BaseEntity
    {

        public String Name { get; set; }
        public ICollection<Employee> Emplyees { get; set; }=new HashSet<Employee>();
    }
}
