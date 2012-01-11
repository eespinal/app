using Machine.Specifications;
using app.web.application.catalogbrowing;
using app.web.core;
using developwithpassion.specifications.extensions;
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
      private Establish c = () =>
                              {
                                the_request = fake.an<IProvideDetailsToCommands>();
                                departments_getter = depends.on<IGetDepartments>();
                              };

      Because b = () =>
        sut.process(the_request);


      It should_get_a_list_of_the_main_departments = () =>
        departments_getter.received(x => x.get_all_departments());

      private static IProvideDetailsToCommands the_request;
      private static IGetDepartments departments_getter;
    }
  }
}