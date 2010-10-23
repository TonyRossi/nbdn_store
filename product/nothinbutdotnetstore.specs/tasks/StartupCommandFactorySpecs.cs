using System;
using System.ComponentModel;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks.startup;
using Rhino.Mocks;
using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs.tasks
{
    [AttributeUsage(AttributeTargets.Method)]
    public class Setup : Attribute
    {
        
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class TestFixture : Attribute
    {
        
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class Test : Attribute
    {
        
    }


    public class Assert
    {
        public static void AreEqual(object expected, object actual)
        {
            actual.ShouldEqual(expected);
        }
    }
    class StartupCommandFactorySpecs
    {
        public abstract class concern : Observes<StartupCommandFactory, DefaultStartupCommandFactory>
        {
        }


        [TestFixture]
        public class when_creating_a_startup_command_from_a_new_type
        {
            Type dependency_type;
            StartupCommand result;
            StartupFacilities the_facilities;
            StartupCommandFactory sut;

            [Setup]
            public void establish()
            {
                dependency_type = typeof(OurStarupCommmand);
                the_facilities = MockRepository.GenerateMock<StartupFacilities>();

                sut = new DefaultStartupCommandFactory(the_facilities);

                because();
            }

            void because()
            {
                result = sut.create_from(dependency_type);
            }

            [Test]
            public void should_return_the_created_command_with_its_facilities_provided()
            {
                Assert.AreEqual(the_facilities, result.downcast_to<OurStarupCommmand>().startup_facilities);
            }

        }

        [Subject(typeof(DefaultStartupCommandFactory))]
        public class when_creating_a_startup_command_from_an_type_that_matches_the_startup_convention : concern
        {
            Establish c = () =>
            {
                startup_facilities = the_dependency<StartupFacilities>();
                dependency_type = typeof(OurStarupCommmand);
            };

            Because b = () =>  
                result = sut.create_from(dependency_type);

            It should_be_able_to_create_a_startup_command_from_its_type = () =>
                result.ShouldBeAn<OurStarupCommmand>().startup_facilities.ShouldEqual(startup_facilities);

            static StartupCommand result;
            static Type dependency_type;
            static StartupFacilities startup_facilities;
        }


        public class OurStarupCommmand : StartupCommand
        {
            public StartupFacilities startup_facilities;

            public OurStarupCommmand(StartupFacilities startup_facilities)
            {
                this.startup_facilities = startup_facilities;
            }

            public void run()
            {
                throw new NotImplementedException();
            }
        }
    }
}