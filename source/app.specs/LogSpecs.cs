using Machine.Specifications;
using app.specs.utility;
using app.utility.logger;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Log))]
  public class LogSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_getting_the_log_gateway : concern
    {
      Establish c = () =>
      {
        logger = fake.an<ILog>();
        using (var scaffold = ObjectFactory.container.scaffold(spec, fake))
        {
          logger_factory = scaffold.an<ICreateLoggers>();
          calling_type_resolver = scaffold.an<IResolveTheCallingType>();
        }

        calling_type_resolver.setup(x => x.get_the_calling_type()).Return(typeof(when_getting_the_log_gateway ));
        logger_factory.setup(x => x.create_logger_bound_to(typeof(when_getting_the_log_gateway)))
          .Return(logger);
      };

      Because b = () =>
        result = Log.an;

      It should_return_a_logger_bound_to_the_type_that_requested_it = () =>
        result.ShouldEqual(logger);

      static ILog logger;
      static ILog result;
      static ICreateLoggers logger_factory;
      static IResolveTheCallingType calling_type_resolver;
    }
  }
}