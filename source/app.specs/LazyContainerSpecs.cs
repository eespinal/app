 using System.Data;
 using Machine.Specifications;
 using app.specs.utility;
 using app.utility.containers.basic;
 using app.utility.containers.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(LazyContainer))]  
  public class LazyContainerSpecs
  {
    public abstract class concern : Observes<IFetchDependencies,
                                      LazyContainer>
    {
        
    }

   
    public class when_fetching_a_dependency : concern
    {
      Establish c = () =>
      {
        the_connection  =ObjectFactory.container.scaffold(spec, fake).an<IDbConnection>();
      };

      Because b = () =>
        result = sut.an<IDbConnection>();


      It should_resolve_the_item_using_the_container_static_gateway = () =>
        result.ShouldEqual(the_connection);


      static IDbConnection result;
      static IDbConnection the_connection;
    }
  }
}
