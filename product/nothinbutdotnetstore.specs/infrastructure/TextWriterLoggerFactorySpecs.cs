 using System.IO;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.logging;
 using nothinbutdotnetstore.infrastructure.logging.basic;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class TextWriterLoggerFactorySpecs
     {
         public abstract class concern : Observes<LoggerFactory,
                                             TextWriterLoggerFactory>
         {
        
         }

         [Subject(typeof(TextWriterLoggerFactory))]
         public class when_creating_a_logger_bound_to_a_type : concern
         {
             Establish c = () =>
             {
                 the_writer_that_should_be_used = new StringWriter();
                 provide_a_basic_sut_constructor_argument<TextWriter>(the_writer_that_should_be_used);
             };

             Because b = () =>
                 result = sut.create_logger_bound_to(typeof(int));

             It should_ignore_the_type_information_and_return_a_text_writer_logger = () =>
             {
                 var writer = result.ShouldBeAn<TextWriterLogger>();
                 writer.writer.ShouldEqual(the_writer_that_should_be_used);
             };

             static Logger result;
             static StringWriter the_writer_that_should_be_used;
         }
     }
 }
