using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class RouteTableSpecs
     {
         public abstract class concern : Observes<RouteTable,
                                             DefaultRouteTable>
         {
        
         }

         [Subject(typeof(DefaultRouteTable))]
         public class when_registering_a_command_with_a_criteria : concern
         {
             private Establish c = () =>
             {
                 criteria = an <RequestCriteria>();
                 command_to_register = an<WebCommand>();
                 web_command_factory = the_dependency<WebCommandFactory>();

                 web_command_factory.Stub(w => w.create_web_command_for<OurCommand>(criteria)).Return((command_to_register));
             };

             Because b = () =>
                 sut.register<OurCommand>(criteria);
             
             It should_contain_a_web_command_with_the_criteria_and_new_application_command_from_type_specified = () =>
                 sut.ShouldContain(command_to_register);

             private static WebCommand command_to_register;
             private static RequestCriteria criteria;
             private static WebCommandFactory web_command_factory;
         }

         internal class OurCommand : ApplicationCommand
         {
             public void process(Request request)
             {
                 throw new NotImplementedException();
             }
         }
     }

 }
