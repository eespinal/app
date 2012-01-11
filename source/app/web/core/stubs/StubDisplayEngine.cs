using System.Collections.Generic;
using System.Web;
using app.web.application.catalogbrowing;

namespace app.web.core.stubs
{
  public class StubDisplayEngine : IDisplayReports
  {
    public void display<Report>(Report report)
    {
      HttpContext.Current.Items.Add("blah", report);
      if (report is IEnumerable<Product>)
        HttpContext.Current.Server.Transfer("~/views/ProductBrowser.aspx", true);
      else
        HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx", true);
    }
  }
}