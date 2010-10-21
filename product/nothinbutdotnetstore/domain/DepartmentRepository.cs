using System.Collections.Generic;

namespace nothinbutdotnetstore.domain
{
    public interface DepartmentRepository
    {
        IEnumerable<Department> get_all_the_main_departments();
    }
}