using System.Collections.Generic;
using nothinbutdotnetstore.domain;

namespace nothinbutdotnetstore.web.application
{
    public class StoreDirectoryController
    {
        StoreDirectory directory;

        public StoreDirectoryController(StoreDirectory directory)
        {
            this.directory = directory;
        }

        public IEnumerable<Department> get_all_main_departments()
        {
            return directory.get_all_the_main_departments();
        }

        public IEnumerable<Department> get_all_departments_in_a(Department department )
        {
            return directory.get_the_departments_in(department);
        }

        public IEnumerable<Product> get_all_products_in_a(Department department)
        {
            return directory.get_the_products_in(department);
        }
    }
}