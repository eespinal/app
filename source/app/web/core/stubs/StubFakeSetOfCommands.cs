using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowing;

namespace app.web.core.stubs
{
  public class StubFakeSetOfCommands:IEnumerable<IProcessASingleRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IProcessASingleRequest> GetEnumerator()
    {
      yield return new RequestHandler(x => true, new ViewSubDepartments());
      yield return new RequestHandler(x => true, new ViewTheMainDepartmentsInTheStore());
    }
  }
}