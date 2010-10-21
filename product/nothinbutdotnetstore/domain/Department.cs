using System.Collections.Generic;

namespace nothinbutdotnetstore.domain
{
    public class Department
    {
        public string name { get; set; }
        public IEnumerable<Department> departments { get; set; }
    }
}