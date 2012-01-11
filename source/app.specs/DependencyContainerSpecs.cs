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
        
      It first_observation = () =>        
        
    }
  }
}
