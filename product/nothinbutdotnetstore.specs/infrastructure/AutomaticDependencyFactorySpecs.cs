 using System;
 using System.Data;
 using System.Data.SqlClient;
 using System.Linq.Expressions;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.infrastructure.containers;
 using nothinbutdotnetstore.infrastructure.containers.basic;
 using Rhino.Mocks;
 using Machine.Specifications.DevelopWithPassion.Extensions;

namespace nothinbutdotnetstore.specs.infrastructure
 {   
     public class AutomaticDependencyFactorySpecs
     {
         public abstract class concern : Observes<DependencyFactory,
                                             AutomaticDependencyFactory>
         {
        
         }

         [Subject(typeof(AutomaticDependencyFactory))]
         public class when_creating_a_dependency_and_it_has_dependencies_also : concern
         {
             Establish c = () =>
             {
                 dependency_container = the_dependency<DependencyContainer>();
                 constructor_selection_strategy = the_dependency<ConstructorSelectionStrategy>();
                 provide_a_basic_sut_constructor_argument(typeof(OurTypeWithLotsOfDependencies));

                 the_connection = new SqlConnection();
                 the_command = new SqlCommand();
                 the_reader = an<IDataReader>();

                 Expression<Func<OurTypeWithLotsOfDependencies>> new_expression = () => new OurTypeWithLotsOfDependencies(null,null,null);
                 var constructor = new_expression.Body.downcast_to<NewExpression>().Constructor;


                 constructor_selection_strategy.Stub(
                     x => x.get_applicable_constructor_on(typeof(OurTypeWithLotsOfDependencies)))
                     .Return(constructor);


                 dependency_container.Stub(x => x.an(typeof(IDbConnection))).Return(the_connection);
                 dependency_container.Stub(x => x.an(typeof(IDbCommand))).Return(the_command);
                 dependency_container.Stub(x => x.an(typeof(IDataReader))).Return(the_reader);
             };

             Because b = () =>
                 result = sut.create();


             It should_create_the_item_with_all_of_its_dependencies_satisfied = () =>
             {
                 var item = result.ShouldBeAn<OurTypeWithLotsOfDependencies>();
                 item.connection.ShouldEqual(the_connection);
                 item.command.ShouldEqual(the_command);
                 item.reader.ShouldEqual(the_reader);
             };

             static object result;
             static SqlConnection the_connection;
             static IDbCommand the_command;
             static IDataReader the_reader;
             static DependencyContainer dependency_container;
             static ConstructorSelectionStrategy constructor_selection_strategy;
         }
     public class OurTypeWithLotsOfDependencies
     {
         public IDbConnection connection;
         public IDataReader reader;
         public IDbCommand command;

         public OurTypeWithLotsOfDependencies(IDbConnection connection, IDbCommand command, IDataReader reader)
         {
             this.connection = connection;
             this.command = command;
             this.reader = reader;
         }

         public OurTypeWithLotsOfDependencies(IDbConnection connection, IDbCommand command)
         {
             this.connection = connection;
             this.command = command;
         }

         public OurTypeWithLotsOfDependencies(IDbConnection connection)
         {
             this.connection = connection;
         }
     }
     }

 }
