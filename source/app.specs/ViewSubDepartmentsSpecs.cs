using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewSubDepartments))]
  public class ViewSubDepartmentsSpecs
  {
    public abstract class concern : Observes<ISupportAStory, ViewSubDepartments>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        display_engine = depends.on<IDisplayReports>();
        _entityRepository = depends.on<IFindInformationInTheStore>();
        current_department = new Department();
        sub_departments = new List<Department> {new Department()};
        the_request = fake.an<IProvideDetailsToCommands>();

        the_request.setup(x => x.map<Department>()).Return(current_department);
        _entityRepository.setup(x => x.get_sub_departments_of(current_department)).Return(sub_departments);
      };

      Because b = () =>
        sut.process(the_request);

      It should_display_the_sub_departments = () =>
        display_engine.received(x => x.display(sub_departments));

      static IProvideDetailsToCommands the_request;
      static IFindInformationInTheStore _entityRepository;
      static IDisplayReports display_engine;
      static Department current_department;
      static IEnumerable<Department> sub_departments;
    }
  }
}