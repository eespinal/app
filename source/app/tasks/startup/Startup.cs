namespace app.tasks.startup
{
  public class Startup
  {
    public static void run()
    {
      Start.by.running<ConfigureTheFrontController>()
        .end_with<ConfiguringRoutes>();
    }
  }
}