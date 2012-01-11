using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowing
{
  public class Department
  {
    public Department()
    {
      Products = new List<Product>();
      SubDepartments = new List<Department>();
    }

    public string name { get; set; }

    public IEnumerable<Product> Products { get; set; }
    public IEnumerable<Department> SubDepartments { get; set; }

    public bool has_products()
    {
      return Products.Count() > 0;
    }

    public bool has_sub_departments()
    {
      return SubDepartments.Count() > 0;
    }
  }

  public class Product
  {
    public string name { get; set; }
  }
}