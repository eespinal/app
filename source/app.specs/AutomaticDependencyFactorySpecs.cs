using System.Data;
using Machine.Specifications;
using app.specs.utility;
using app.utility.containers.basic;
using app.utility.containers.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(AutomaticDependencyFactory))]
  public class AutomaticDependencyFactorySpecs
  {
    public abstract class concern : Observes<ICreateOneType,
                                      AutomaticDependencyFactory>
    {
    }

    public class when_creating_a_type : concern
    {
      Establish c = () =>
      {
        the_container = depends.on<IFetchDependencies>();
        pick_the_ctor_on_the_type = depends.on<IPickTheCtorOnTheType>();
        depends.on(typeof(OurTypeWithDependencies));

        the_connection = fake.an<IDbConnection>();
        the_command = fake.an<IDbCommand>();
        the_reader = fake.an<IDataReader>();

        pick_the_ctor_on_the_type.setup(x => x.get_applicable_ctor_on(typeof(OurTypeWithDependencies)))
          .Return(ObjectFactory.expressions.to_target<OurTypeWithDependencies>()
                    .get_ctor_pointed_at_by(() => new OurTypeWithDependencies(null, null, null)));

        the_container.setup(x => x.an(typeof(IDbConnection))).Return(the_connection);
        the_container.setup(x => x.an(typeof(IDbCommand))).Return(the_command);
        the_container.setup(x => x.an(typeof(IDataReader))).Return(the_reader);
      };

      Because b = () =>
        result = sut.create();

      It should_create_the_type_and_fill_all_of_its_dependencies = () =>
      {
        var item = result.ShouldBeAn<OurTypeWithDependencies>();

        item.connection.ShouldEqual(the_connection);
        item.command.ShouldEqual(the_command);
        item.reader.ShouldEqual(the_reader);
      };

      static object result;
      static IDbConnection the_connection;
      static IDbCommand the_command;
      static IDataReader the_reader;
      static IFetchDependencies the_container;
      static IPickTheCtorOnTheType pick_the_ctor_on_the_type;
    }

    public class OurTypeWithDependencies
    {
      public IDbConnection connection;
      public IDbCommand command;
      public IDataReader reader;

      public OurTypeWithDependencies(IDbConnection connection, IDbCommand command, IDataReader reader)
      {
        this.connection = connection;
        this.command = command;
        this.reader = reader;
      }


      public OurTypeWithDependencies(IDbConnection connection, IDbCommand command)
      {
        this.connection = connection;
        this.command = command;
      }

      public OurTypeWithDependencies(IDbConnection connection)
      {
        this.connection = connection;
      }
    }
  }
}