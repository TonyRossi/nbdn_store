 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.domain;
 using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class ViewMainDeparmentsInTheStoreSpecs
     {
         public abstract class concern : Observes<ApplicationCommand,
                                             ViewMainDeparmentsInTheStore>
         {
        
         }

         [Subject(typeof(ViewMainDeparmentsInTheStore))]
         public class when_processing_the_request : concern
         {

             Establish c = () =>
             {
                 request =an<Request>();
                 response_engine = the_dependency<ResponseEngine>();
                 main_departments = new List<Department> {new Department()};

                 store_directory = the_dependency<StoreDirectory>();

                 store_directory.Stub(x => x.get_all_the_main_departments()).Return(main_departments);
             };

             Because b = () =>
                 sut.process(request);

//             It should_go_get_the_list_of_the_main_departments = () =>
//                 department_repository.received(x => x.get_all_the_main_departments());

             It should_tell_the_response_engine_to_display_the_departments = () =>
                 response_engine.received(x => x.display(main_departments));
  
             static StoreDirectory store_directory;
             static Request request;
             static ResponseEngine response_engine;
             static IEnumerable<Department> main_departments;
         }
     }
 }
