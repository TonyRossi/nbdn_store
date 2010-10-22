 using System.Collections.Specialized;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.application.mappers;

namespace nothinbutdotnetstore.specs.web
 {   
     public class InputKeySpecs
     {
         public abstract class concern : Observes<InputKey<int>>
         {
        
         }

         [Subject(typeof(InputKey<>))]
         public class when_implcitly_converting_to_a_string : concern
         {
             Establish c = () =>
             {
                 the_key_name = "bla";
                 provide_a_basic_sut_constructor_argument(the_key_name);
             };

             Because b = () =>
                 result = sut;

             It should_return_the_name_of_the_key = () =>
                 result.ShouldEqual(the_key_name);


             static string result;
             static string the_key_name;
         }

         [Subject(typeof(InputKey<>))]
         public class when_explcitly_converting_to_a_string : concern
         {
             Establish c = () =>
             {
                 the_key_name = "bla";
                 provide_a_basic_sut_constructor_argument(the_key_name);
             };

             Because b = () =>
                 result = sut.ToString();

             It should_return_the_name_of_the_key = () =>
                 result.ShouldEqual(the_key_name);


             static string result;
             static string the_key_name;
         }

         [Subject(typeof(InputKey<>))]
         public class when_mapping_from_a_name_value_collection : concern
         {
             Establish c = () =>
             {
                 the_key_name = "bla";
                 the_number = 42;
                 the_payload = new NameValueCollection();
                 provide_a_basic_sut_constructor_argument(the_key_name);

                 the_payload.Add(the_key_name,the_number.ToString());
             };

             Because b = () =>
                 result = sut.map_from(the_payload);

             It should_return_the_value_strongly_typed = () =>
                 result.ShouldEqual(the_number);


             static int result;
             static string the_key_name;
             static int the_number;
             static NameValueCollection the_payload;
         }
     }
 }
