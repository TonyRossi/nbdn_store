using System;
using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewFactorySpecs
    {
        public abstract class concern : Observes<ViewFactory,
                                            HttpHandlerViewFactory>
        {
        }

        [Subject(typeof(HttpHandlerViewFactory))]
        public class when_creating_a_view_that_can_display_a_view_model : concern
        {
            Establish c = () =>
            {
                view_registry = the_dependency<ViewRegistry>();
                the_real_path = "blah.foo";
                the_correct_type = typeof(ViewForA<OurModel>);
                the_model = new OurModel();
                our_view = an<ViewForA<OurModel>>();

                view_registry.Stub(x => x.get_the_path_to_the_view_that_can_display<OurModel>())
                    .Return(the_real_path);

                provide_a_basic_sut_constructor_argument<PageFactory>((path, type) =>
                {
                    path_provided = path;
                    type_provided = type;
                    return our_view;
                });
            };

            Because b = () =>
                result = sut.create_a_view_that_can_display(the_model);

            It should_find_a_view_that_can_display_the_view_model = () =>
                view_registry.received(x => x.get_the_path_to_the_view_that_can_display<OurModel>());

            It should_create_the_view_using_the_correct_path_and_type = () =>
            {
                path_provided.ShouldEqual(the_real_path);
                type_provided.ShouldEqual(the_correct_type);
            };

            It should_provide_the_view_with_its_model = () =>
                our_view.model.ShouldEqual(the_model);

            It should_return_the_view = () =>
                result.ShouldEqual(our_view);
  

            static ViewRegistry view_registry;
            static OurModel the_model;
            static string path_provided;
            static string the_real_path;
            static Type type_provided;
            static Type the_correct_type;
            static ViewForA<OurModel> our_view;
            static IHttpHandler result;
        }

        public class OurModel
        {
        }
    }
}