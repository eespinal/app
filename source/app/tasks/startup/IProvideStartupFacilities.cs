using app.web.core.stubs;

namespace app.tasks.startup
{
  public interface IProvideStartupFacilities
  {
    void register_factory_for<T, T1>();
    void register_instance_for<T>(T instance);
  }
}