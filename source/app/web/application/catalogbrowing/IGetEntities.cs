using System.Collections.Generic;

namespace app.web.application.catalogbrowing
{
  public interface IGetEntities
  {
    IEnumerable<Department> get_the_main_departments();
    IEnumerable<Department> get_sub_departments_of(Department department);
    IEnumerable<Product> get_products_of(Department currentDepartment);
  }
}