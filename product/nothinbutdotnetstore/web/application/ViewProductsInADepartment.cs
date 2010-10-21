using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProductsInADepartment : ApplicationCommand
    {
        ResponseEngine response_engine;
        StoreDirectory store_directory;

        public ViewProductsInADepartment(ResponseEngine response_engine, StoreDirectory store_directory)
        {
            this.response_engine = response_engine;
            this.store_directory = store_directory;
        }

        public void process(Request request)
        {
            response_engine.display(store_directory.get_the_products_in(request.map<Department>()));
        }
    }
}