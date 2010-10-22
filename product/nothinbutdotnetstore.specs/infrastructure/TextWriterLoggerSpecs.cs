using System.IO;
using System.Text;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.basic;

namespace nothinbutdotnetstore.specs.infrastructure
{
    public class TextWriterLoggerSpecs
    {
        public abstract class concern : Observes<Logger,
                                            TextWriterLogger>
        {
        }

        [Subject(typeof(TextWriterLogger))]
        public class when_logging_an_informational_message : concern
        {
            Establish c = () =>
            {
                builder = new StringBuilder();
                provide_a_basic_sut_constructor_argument<TextWriter>(new StringWriter(builder));
            };

            Because b = () =>
                sut.informational("this is the message");

            It should_write_the_message_to_the_text_writer_backing_store = () =>
                builder.ToString().ShouldBeEqualIgnoringCase("this is the message\r\n");

            static StringBuilder builder;
        }
    }
}