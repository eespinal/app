using System.Collections.Generic;
using app.web.application.catalogbrowing;
using app.web.core.aspnet;

namespace app.web.core.stubs
{
  public class StubPathRegistry : IFindPathsToTemplates
  {
    public string get_path_to_template_for<ReportModel>()
    {
      if (typeof(ReportModel) == typeof(IEnumerable<Department>)) return get_path_for("Department");

      return get_path_for("Product");
    }

    string get_path_for(string view)
    {
      return string.Format("~/views/{0}Browser.aspx", view);
    }
  }
}