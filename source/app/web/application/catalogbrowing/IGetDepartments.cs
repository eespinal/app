using System.Collections.Generic;

namespace app.web.application.catalogbrowing
{
  public interface IGetDepartments
  {
    IEnumerable<Department> get_the_main_departments();
    IEnumerable<Department> get_sub_departments_of(int parent_department_id);
  }
}