using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.domain.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewDepartmentsInDepartment : ApplicationCommand
    {
        StoreDirectory store_directory;
        ResponseEngine response_engine;

        public ViewDepartmentsInDepartment()
            : this(new StubStoreDirectory(),
                   new WebFormResponseEngine())
        {
        }

        public ViewDepartmentsInDepartment(StoreDirectory store_directory, ResponseEngine response_engine)
        {
            this.store_directory = store_directory;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(store_directory.get_the_departments_in(request.map<Department>()));
        }
    }
}