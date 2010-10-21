using System.Collections.Generic;

namespace nothinbutdotnetstore.domain
{
    public interface DepartmentRepository
    {
        IEnumerable<Department> get_all_the_main_departments();
        IEnumerable<Department> get_the_departments_in_the_department(Department department_with_children);
    }
}