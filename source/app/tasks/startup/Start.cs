using System;
using app.utility.containers.core;

namespace app.tasks.startup
{
    public delegate IBuildAnStartupPipeline IGetStartupPipelineBuilder();

    public class Start
    {
        public static IGetStartupPipelineBuilder factory = ()=>
        {
            throw new NotImplementedException("You need to set this in the bootstrapper");
        };

        public static object by
        {
            get { return factory();}
        }
    }
}