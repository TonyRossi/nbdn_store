using nothinbutdotnetstore.domain;

namespace nothinbutdotnetstore.web.core
{
    public interface Request
    {
        Department DepartmentToProcess { get; set; }
    }
}