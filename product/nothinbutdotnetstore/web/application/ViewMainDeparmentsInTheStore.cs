using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.domain.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDeparmentsInTheStore : ApplicationCommand
    {
        StoreDirectory store_directory;
        ResponseEngine response_engine;

        public ViewMainDeparmentsInTheStore() : this(new StubStoreDirectory(),
                                                     new WebFormResponseEngine())
        {
        }

        public ViewMainDeparmentsInTheStore(StoreDirectory store_directory, ResponseEngine response_engine)
        {
            this.store_directory = store_directory;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(store_directory.get_all_the_main_departments());
        }
    }
}