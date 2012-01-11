using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowing.stubs
{
  public class StubStoreCatalog : IFindInformationInTheStore
  {

    public IEnumerable<Department> get_the_main_departments()
    {
      return Enumerable.Range(1, 10).Select(x =>
                                              {
                                                return new Department{name = x.ToString("Main Deparment 0"),has_products = x % 3 == 0,has_sub_departments = x % 2 == 0};
                                              });
    }

    public IEnumerable<Department> get_sub_departments_of(Department parent)
    {
      return Enumerable.Range(1, 100).Select(x =>
                                               {
                                                return new Department{name = x.ToString("Sub Deparment 0"),has_products = x % 3 == 0,has_sub_departments = x % 2 == 0};
                                               });
    }

    public IEnumerable<Product> get_products_of(Department currentDepartment)
    {
      return Enumerable.Range(1, 100).Select(x => new Product {name = x.ToString("Product 0")});
    }

  }
}