using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class MissingDependencyFactorySpecs
     {
         public abstract class concern : Observes<DependencyFactory ,
                                             MissingDependencyFactory>
         {
        
         }

         [Subject(typeof(MissingDependencyFactory))]
         public class when_told_to_create_a_dependency : concern
         {

             Establish c = () =>
             {
                 provide_a_basic_sut_constructor_argument(typeof(int));
             };

             Because b = () =>
                 catch_exception(() => sut.create());


             It should_throw_an_exception_message_that_indicates_the_type_that_has_no_factory = () =>
                 exception_thrown_by_the_sut.Message.ShouldContain(typeof(int).Name);

                 
         }
     }
 }
