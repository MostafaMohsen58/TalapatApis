using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapat.Core.Entities;

namespace Talapat.Core.specifications
{
    public class EmployeeAndDepartmentSpecifications:BaseSpecifications<Employee>
    {
        public EmployeeAndDepartmentSpecifications()
        {
            Includes.Add(E => E.Department);// Load Nav Property
        }
        public EmployeeAndDepartmentSpecifications(int id):base(E=>E.Id==id ) 
        {
                     Includes.Add(E => E.Department);// Load Nav Property
       
        }


}
}
