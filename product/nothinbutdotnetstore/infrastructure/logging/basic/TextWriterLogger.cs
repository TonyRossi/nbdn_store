using System;
using System.IO;

namespace nothinbutdotnetstore.infrastructure.logging.basic
{
    public class TextWriterLogger : Logger
    {
        private TextWriter writer;

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