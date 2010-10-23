using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.specs.tasks
{
    public class StartupFacilitiesSpecs
    {
        public abstract class concern : Observes<StartupFacilities,
                                            DefaultStartupFacilities>
        {
        }

        [Subject(typeof(DefaultStartupFacilities))]
        public class when_registering_a_dependency_with_its_contract_and_implementation_specified : concern
        {
            Establish c = () =>
            {
                dependency_container = the_dependency<DependencyContainer>();
                dependencies = new Dictionary<Type, DependencyFactory>();
                provide_a_basic_sut_constructor_argument(dependencies);
            };

            Because b = () =>
                sut.register<IDbConnection, SqlConnection>();

            It should_register_an_autowiring_factory_that_will_be_used_to_create_the_dependency = () =>
            {
                var item = dependencies[typeof(IDbConnection)].ShouldBeAn<AutomaticDependencyFactory>();
                item.dependency_container.ShouldEqual(dependency_container);
                item.type.ShouldEqual(typeof(SqlConnection));
                item.constructor_selection_strategy.ShouldBeAn<GreedyConstructorSelectionStrategy>();
            };

            static IDictionary<Type, DependencyFactory> dependencies;
            static DependencyContainer dependency_container;
        }

        [Subject(typeof(DefaultStartupFacilities))]
        public class when_registering_a_dependency_with_a_contract_and_provided_instance : concern
        {
            Establish c = () =>
            {
                the_connection = new SqlConnection();
                dependencies = new Dictionary<Type, DependencyFactory>();
                provide_a_basic_sut_constructor_argument(dependencies);
            };

            Because b = () =>
                sut.register(the_connection);

            It should_register_a_basic_dependency_factory_that_return_the_same_instance = () =>
            {
                var item = dependencies[typeof(IDbConnection)].ShouldBeAn<BasicDependencyFactory>();
                item.create().ShouldEqual(the_connection);
            };

            static IDictionary<Type, DependencyFactory> dependencies;
            static IDbConnection the_connection;
        }

        [Subject(typeof(DefaultStartupFacilities))]
        public class when_requesting_the_dependencies_dictionary : concern
        {
            Establish c = () =>
            {
                dependencies = new Dictionary<Type, DependencyFactory>();
                provide_a_basic_sut_constructor_argument(dependencies);
            };

            Because b = () =>
                result = sut.original_factories;

            It should_return_the_dictionary_it_is_created_with = () => { result.ShouldEqual(dependencies); };

            static IDictionary<Type, DependencyFactory> dependencies;
            static IDictionary<Type, DependencyFactory> result;
        }
    }
}