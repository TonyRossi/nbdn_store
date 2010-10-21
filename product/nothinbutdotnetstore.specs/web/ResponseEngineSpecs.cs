using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ResponseEngineSpecs
    {
        public abstract class concern : Observes<ResponseEngine,
                                            WebFormResponseEngine>
        {
        }

        [Subject(typeof(WebFormResponseEngine))]
        public class when_displaying_a_view_model : concern
        {
            Establish c = () =>
            {
                the_view_model = new OurViewModel(); 
                view = an<IHttpHandler>();
                the_context = ObjectMother.create_http_context();
                view_factory = the_dependency<ViewFactory>();
                view_factory.Stub(x => x.create_a_view_that_can_display(the_view_model)).Return(view);

                provide_a_basic_sut_constructor_argument<CurrentContextResolver>(() => the_context);
            };

            Because b = () =>
                sut.display(the_view_model);

//            It should_tell_the_view_factory_to_create_a_view_that_can_display_the_model = () =>
//                view_factory.received(x => x.create_a_view_that_can_display(the_view_model));

            It should_tell_the_view_to_process_using_the_active_context = () =>
                view.received(x => x.ProcessRequest(the_context));
  
  

            static OurViewModel the_view_model;
            static ViewFactory view_factory;
            static IHttpHandler view;
            static HttpContext the_context;
        }

        class OurViewModel
        {
        }
    }
}