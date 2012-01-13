namespace app.web.core.aspnet
{
  public interface IFindPathsToTemplates
  {
    string get_path_to_template_for<ReportModel>();
    void register_path_for_template<ReportModel>(string path);
  }
}