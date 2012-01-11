 using Machine.Specifications;
 using app.utility.containers;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(DependencyContainer))]  
  public class DependencyContainerSpecs
  {
    public abstract class concern : Observes<IFetchDependencies,
                                      DependencyContainer>
    {
        
    }

   
    public class when_getting_a_dependency : concern
    {
        Because of = () => result = sut.an<IStubDependency>();
                         
        It should_return_a_valid_instance = () => result.ShouldBeAn<IStubDependency>();

        static IStubDependency result;
        
    }

    public interface IStubDependency
    {
         
    }
  }
}
