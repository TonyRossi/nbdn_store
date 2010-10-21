using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.domain.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDeparmentsInTheStore : ApplicationCommand
    {
        DepartmentRepository department_repository;
        ResponseEngine response_engine;

        public ViewMainDeparmentsInTheStore():this(new StubDepartmentRepository(),
            new StubResponseEngine())
        {
        }

        public ViewMainDeparmentsInTheStore(DepartmentRepository department_repository, ResponseEngine response_engine)
        {
            this.department_repository = department_repository;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(department_repository.get_all_the_main_departments());
        }
    }
}