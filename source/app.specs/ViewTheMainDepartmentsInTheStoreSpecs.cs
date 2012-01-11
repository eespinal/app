using System.Collections.Generic;
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
      Establish c = () =>
      {
        display_engine = depends.on<IDisplayReports>();
        department_repository = depends.on<IGetDepartments>();
        the_main_departments = new List<Department> {new Department()};
        the_request = fake.an<IProvideDetailsToCommands>();

        department_repository.setup(x => x.get_the_main_departments()).Return(the_main_departments);
      };

      Because b = () =>
        sut.process(the_request);


      It should_display_the_main_departments = () =>
        display_engine.received(x => x.display(the_main_departments));
        

      static IProvideDetailsToCommands the_request;
      static IGetDepartments department_repository;
      static IDisplayReports display_engine;
      static IEnumerable<Department> the_main_departments;
    }
  }
}