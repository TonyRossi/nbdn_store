 using System.Collections.Generic;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.domain;
 using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class ViewProductsInADepartmentSpecs
     {
         public abstract class concern : Observes<ApplicationCommand,
                                             ViewProductsInADepartment>
         {
        
         }

         [Subject(typeof(ViewProductsInADepartment))]
         public class when_processing_the_request : concern
         {
             Establish c = () =>
             {
                 request = an<Request>();
                 response_engine = the_dependency<ResponseEngine>();
                 product_repository = the_dependency<ProductRepository>();
                 the_products_in_a_department = new List<Product>();
                 department_with_products = new Department();

                 request.Stub(x => x.map<Department>()).Return(department_with_products);
                 product_repository.Stub(x => x.get_the_products_in(department_with_products)).Return(the_products_in_a_department);
             };
             Because b = () =>
                 sut.process(request);


             It should_display_all_of_the_products_in_a_department = () =>
                 response_engine.received(x => x.display(the_products_in_a_department));

             static ResponseEngine response_engine;
             static IEnumerable<Product> the_products_in_a_department;
             static Request request;
             static ProductRepository product_repository;
             static Department department_with_products;
         }
     }
 }
