using System.Collections.Generic;

namespace nothinbutdotnetstore.domain
{
    public interface ProductRepository
    {
        IEnumerable<Product> get_the_products_in(Department department);
    }
}