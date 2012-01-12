using System.Collections.Generic;
using app.utility.containers.basic;

namespace app.tasks.startup
{
  public interface IProvideStartupFacilities:IEnumerable<ICreateASingleDependency>
  {
    void register_factory_for<Contract, Implementation>() where Implementation : Contract;
    void register_factory_for<Contract>();
    void register_instance_for<Contract>(Contract instance);
  }
}