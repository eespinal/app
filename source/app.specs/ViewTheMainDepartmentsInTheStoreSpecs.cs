using Machine.Specifications;
using app.web.application.catalogbrowing;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
  public class ViewTheMainDepartmentsInTheStoreSpecs
  {
    public abstract class concern : Observes<ISupportAStory,
                                      ViewTheMainDepartmentsInTheStore>
    {
    }

    public class when_run : concern
    {
      It should_get_a_list_of_the_main_departments = () => 
    }
  }
}