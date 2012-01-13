namespace app.tasks.startup
{
  public class Startup
  {
    public static void run()
    {
      Start.by.running<ConfigureCoreServices>()
        .followed_by<ConfigureLogging>()
        .followed_by<ConfigureTheFrontController>()
        .followed_by<ConfigureQueries>()
        .end_with<ConfiguringRoutes>();
    }
  }
}