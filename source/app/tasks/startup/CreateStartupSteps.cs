using System;
using System.Reflection;
using System.Linq;
using app.utility.containers.core;

namespace app.tasks.startup
{
    public class CreateStartupSteps : ICreateStartupSteps
    {
        IProvideStartupFacilities startup_facility;

        public CreateStartupSteps(IProvideStartupFacilities startup_facility)
        {
            this.startup_facility = startup_facility;
        }

        public IRunAStartupStep create_from(Type startup_step_type)
        {
            var constructors = startup_step_type.GetConstructors();
            validate_constructors(constructors);
            var instance = constructors.First().Invoke(new[] {startup_facility}) as IRunAStartupStep;
            return instance;
        }

        void validate_constructors(ConstructorInfo[] constructors)
        {
        }
    }
}