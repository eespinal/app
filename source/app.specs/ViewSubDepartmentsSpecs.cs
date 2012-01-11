using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject( typeof( ViewSubDepartments ) )]
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
        department_repository = depends.on<IGetDepartments>();
      	current_department = new Department{ id = 1 };
		sub_departments = new List<SubDepartment> { new SubDepartment() };
        the_request = fake.an<IProvideDetailsToCommands>();

      	current_department = new Department{ id = 1 };
		department_repository.setup( x => x.get_sub_departments_of( current_department.id ) ).Return( sub_departments );
      };

      Because b = () =>
        sut.process(the_request);


      It should_display_the_main_departments = () =>
        display_engine.received(x => x.display(current_department));

      static IProvideDetailsToCommands the_request;
      static IGetDepartments department_repository;
      static IDisplayReports display_engine;
      static Department current_department;
      static List<SubDepartment> sub_departments;
    }
  }
}