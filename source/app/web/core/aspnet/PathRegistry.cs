using System;
using System.Collections.Generic;

namespace app.web.core.aspnet
{
  public class PathRegistry : IFindPathsToTemplates, IRegisterPaths
  {
    IDictionary<Type, string> paths;
    TemplatePathAlreadyRegisteredExceptionFactory factory;

    public PathRegistry(IDictionary<Type, string> paths, TemplatePathAlreadyRegisteredExceptionFactory factory)
    {
      this.paths = paths;
      this.factory = factory;
    }

    public PathRegistry(TemplatePathAlreadyRegisteredExceptionFactory factory):this(new Dictionary<Type, string>(),factory)
    {
    }

    public string get_path_to_template_for<ReportModel>()
    {
      return paths[typeof(ReportModel)];
    }

    public void register_path_for_template<ReportModel>(string path)
    {
      try
      {
        paths.Add(typeof(ReportModel), path);
      }
      catch (ArgumentException)
      {
        throw factory(typeof(ReportModel));
      }
    }
  }
}