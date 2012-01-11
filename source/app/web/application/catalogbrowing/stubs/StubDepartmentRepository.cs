using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowing.stubs
{
  public class StubDepartmentRepository : IGetDepartments
  {
    public IEnumerable<Department> get_the_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Main Deparment 0")});
    }

    public IEnumerable<Department> get_sub_departments_of(Department parent)
    {
      return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Sub Deparment 0")});
    }
  }
}