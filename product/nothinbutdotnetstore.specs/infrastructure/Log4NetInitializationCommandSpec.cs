 using System;
 using System.IO;
 using System.Xml;
 using log4net;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.logging.log4net;
 using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class Log4NetInitializationCommandSpec
     {
         public abstract class concern : Observes<Log4NetInitializationCommand,
                                             Log4NetInitializationCommand>
         {
        
         }

         [Subject(typeof(Log4NetInitializationCommand))]
         public class when_initialization_has_been_completed : concern
         {

             Establish c = () =>
             {
                 provide_a_basic_sut_constructor_argument(Log4NetConfigSection.create_config_element_to_target(the_logging_file));     
                 add_pipeline_behaviour(() => { },() =>
                 {
                     File.Delete(the_logging_file);
                 });
             };

             Because b = () =>
                 sut.run();


             It should_successfully_log_to_the_configured_location = () =>
             {
                 LogManager.GetLogger(typeof(int)).Info("This is a log message");
                 LogManager.Shutdown();
                 File.Exists(the_logging_file).ShouldBeTrue();
             };

             protected static string the_logging_file
             {
                 get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "the_log_file.txt"); }
             }
         }

         public class Log4NetConfigSection
         {
             public const string config_file_format =
                 @"<log4net>
        <appender name='RollingFileAppender' type='log4net.Appender.RollingFileAppender'>
            <file value='{0}' />
            <appendToFile value='true' />
            <rollingStyle value='Size' />
            <maxSizeRollBackups value='10' />
            <maximumFileSize value='100000KB' />
            <staticLogFileName value='true' />
            <layout type='log4net.Layout.PatternLayout'>
                <conversionPattern value='%d [%t] %-5p %c - %m%n' />
            </layout>
        </appender>

        <root>
            <level value='DEBUG' />
            <appender-ref ref='RollingFileAppender' />			
        </root>
    </log4net>
";
             public static XmlElement create_config_element_to_target(string the_logging_file)
             {
                 var document = new XmlDocument();
                 document.LoadXml(config_file_format.format_using(the_logging_file));
                 return document.DocumentElement;
             }
         }
     }
 }
