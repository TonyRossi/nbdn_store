using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.domain.stubs
{
    public class StubDepartmentRepository : DepartmentRepository
    {
        public IEnumerable<Department> get_all_the_main_departments()
        {
            return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Department 0")});
        }

        public IEnumerable<Department> get_the_departments_in_the_department(Department department)
        {
            return department.departments;
        }
    }
}