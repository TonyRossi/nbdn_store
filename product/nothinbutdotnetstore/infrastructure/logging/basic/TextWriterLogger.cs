using System.IO;

namespace nothinbutdotnetstore.infrastructure.logging.basic
{
    public class TextWriterLogger : Logger
    {
        public TextWriter writer { get; private set; }

        public TextWriterLogger(TextWriter writer)
        {
            this.writer = writer;
        }

        public void informational(string message)
        {
            writer.WriteLine(message);
        }
    }
}