using System;

namespace app.web.core.aspnet
{
  public interface IFindPathsToTemplates
  {
    Uri  get_path_to_template_for<ReportModel>();
  }
}