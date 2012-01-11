using System.Collections;
using System.Collections.Generic;
using app.utility;
using app.web.application.catalogbrowing;
using app.web.application.catalogbrowing.stubs;

namespace app.web.core.stubs
{
  public class StubFakeSetOfCommands : IEnumerable<IProcessASingleRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IProcessASingleRequest> GetEnumerator()
    {
      yield return new RequestHandler(x => x.map<Department>().has_products, new ViewA<IEnumerable<Product>>(new GetTheProducts()));
      yield return new RequestHandler(x => x.map<Department>().has_sub_departments, new ViewA<IEnumerable<Department>>(new GetTheDepartmentsInADepartment()));
      yield return new RequestHandler(x => true, new ViewA<IEnumerable<Department>>(new GetTheMainDepartments())); 
    }
  }

  public class GetTheMainDepartments : IFetchA<IEnumerable<Department>>
  {
    public IEnumerable<Department> fetch_using(IProvideDetailsToCommands request)
    {
      return Stub.with<StubStoreCatalog>().get_the_main_departments();
    }
  }

  public class GetTheDepartmentsInADepartment : IFetchA<IEnumerable<Department>>
  {
    public IEnumerable<Department> fetch_using(IProvideDetailsToCommands request)
    {
      return Stub.with<StubStoreCatalog>().get_sub_departments_of(request.map<Department>());
    }
  }

  public class GetTheProducts : IFetchA<IEnumerable<Product>>
  {
    public IEnumerable<Product> fetch_using(IProvideDetailsToCommands request)
    {
      return Stub.with<StubStoreCatalog>().get_products_of(request.map<Department>());
    }
  }
}