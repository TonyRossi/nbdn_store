 using System;
 using System.Collections.Specialized;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.domain;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.web.application.mappers;

namespace nothinbutdotnetstore.specs.web
 {   
     public class DepartmentMapperSpecs
     {
         public abstract class concern : Observes<Mapper<NameValueCollection,Department>,
                                             DepartmentMapper>
         {
        
         }

         [Subject(typeof(DepartmentMapper))]
         public class when_mapping_from_a_name_value_collection : concern
         {
             Establish c = () =>
             {
                 values = new NameValueCollection();
                 prototype = new Department
                 {
                     name = "this is the name",
                     address = "This is the address",
                     created_on = new DateTime(2001, 10, 10),
                     number_of_items = 200,
                     phone = "555-2233"
                 };

                 values.Add(InputKeys.department.name,prototype.name);
                 values.Add(InputKeys.department.address,prototype.address);
                 values.Add(InputKeys.department.created_on,prototype.created_on.ToShortDateString());
                 values.Add(InputKeys.department.number_of_items,prototype.number_of_items.ToString());
                 values.Add(InputKeys.department.phone,prototype.phone);
             };

             Because b = () =>
                 result = sut.map_from(values);

             It should_return_the_department_with_all_of_the_correct_information = () =>
             {
                 result.ShouldEqual(prototype);
             };

             static Department result;
             static string the_name;
             static Department prototype;
             static NameValueCollection values;
         }
     }
 }
