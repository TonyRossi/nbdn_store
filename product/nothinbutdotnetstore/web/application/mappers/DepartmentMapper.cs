using System.Collections.Specialized;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.application.mappers
{
    public class DepartmentMapper : Mapper<NameValueCollection, Department>
    {
        public Department map_from(NameValueCollection input)
        {
            return new Department
            {
                name = InputKeys.department.name.map_from(input),
                address = InputKeys.department.address.map_from(input),
                phone = InputKeys.department.phone.map_from(input),
                created_on = InputKeys.department.created_on.map_from(input),
                number_of_items = InputKeys.department.number_of_items.map_from(input)
            };
        }
    }
}