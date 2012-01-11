
using System;
using System.Collections.Generic;
using System.Web;
using app.web.application.catalogbrowing;
using app.web.application.catalogbrowing.stubs;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateRequests
  {
    public IProvideDetailsToCommands create_request_from(HttpContext a_context)
    {
      return new StubRequest();
    }

    class StubRequest : IProvideDetailsToCommands
    {
      public InputModel map<InputModel>()
      {
        object item;
        var rand = (new Random()).Next(0, 4);
        switch (rand)
        {
          case 0:
            item = new Department(){Products = new List<Product>(){new Product(),new Product()}};
            break;
          case 1:
            item = new Department() {SubDepartments= new List<Department>() { new Department(), new Department() } };
            break;
          default:
            item = new Department();
          break;
        }
        return (InputModel) item;
      }
    }
  }
}