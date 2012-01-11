using System.Collections.Generic;

namespace app.web.application.catalogbrowing
{
  public interface IGetDepartments
  {
    IEnumerable<Department> get_the_main_departments();
  }
}