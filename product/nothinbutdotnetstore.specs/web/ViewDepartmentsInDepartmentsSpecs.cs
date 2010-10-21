using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.domain;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;


namespace nothinbutdotnetstore.specs.web
{
    public class ViewDepartmentsInDepartmentsSpecs
     {
         public abstract class concern : Observes<ApplicationCommand,
                                             ViewDepartmentsInDepartment>
         {
        
         }

         [Subject(typeof(ViewDepartmentsInDepartment))]
         public class when_processing_the_request : concern
         {

             Establish c = () =>
             {
                 request =an<Request>();
                 response_engine = the_dependency<ResponseEngine>();
                 departments_in = new List<Department>()
                                      {
                                          new Department() {name = "Fun Department 1"},
                                          new Department() {name = "Fun Department 2"}
                                      };
                 departments = new List<Department> {new Department(){name="Department", departments = departments_in}};

                 department_repository = the_dependency<DepartmentRepository>();

                 department_repository.Stub(x => x.get_all_the_main_departments()).Return(departments);
             };

             Because b = () =>
                 sut.process(request);


             It should_tell_the_response_engine_to_display_the_departments = () =>
                 response_engine.received(x => x.display(departments));
  
             static DepartmentRepository department_repository;
             static Request request;
             static ResponseEngine response_engine;
             static IEnumerable<Department> departments;
             static IEnumerable<Department> departments_in;
         }
     }
}
