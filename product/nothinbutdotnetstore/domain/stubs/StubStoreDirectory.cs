using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.domain.stubs
{
    public class StubStoreDirectory : StoreDirectory
    {
        public IEnumerable<Department> get_all_the_main_departments()
        {
            return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Department 0")});
        }

        public IEnumerable<Product> get_the_products_in(Department department)
        {
            return Enumerable.Range(1, 100).Select(x => new Product {});
        }

        public IEnumerable<Department> get_the_departments_in(Department department)
        {
            return
                Enumerable.Range(1, 100).Select(
                    x => new Department {name = x.ToString("A Department In A Department 0")});
        }
    }
}