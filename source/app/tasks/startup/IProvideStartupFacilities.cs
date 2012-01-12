namespace app.tasks.startup
{
  public interface IProvideStartupFacilities
  {
    void register_factory_for<Contract, Implementation>() where Implementation : Contract;
    void register_factory_for<Contract>();
    void register_instance_for<Contract>(Contract instance);
  }
}