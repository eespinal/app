using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using app.utility.containers.core;
using developwithpassion.specifications.core;
using developwithpassion.specifications.extensions;

namespace app.specs.utility
{
  public class ObjectFactory
  {
    public static class expressions
    {
      public static ExpressionBuilder<ItemToTarget> to_target<ItemToTarget>()
      {
        return new ExpressionBuilder<ItemToTarget>();
      }

      public class ExpressionBuilder<ItemToTarget>
      {
        public ConstructorInfo get_ctor_pointed_at_by(Expression<Func<ItemToTarget>> ctor)
        {
          return ctor.Body.downcast_to<NewExpression>().Constructor;
        }
      }
    }

    public class container
    {
      public class ContainerScaffold
      {
        readonly IConfigureSpecifications spec;
        readonly ICreateFakes fake;

        public ContainerScaffold(IConfigureSpecifications spec, ICreateFakes fake)
        {
          this.spec = spec;
          this.fake = fake;
        }

        public TheDependency an<TheDependency>() where TheDependency : class
        {
          var the_container = fake.an<IFetchDependencies>();
          ContainerFacadeResolver resolver = () => the_container;

          var dependency = fake.an<TheDependency>();
          the_container.setup(x => x.an<TheDependency>()).Return(dependency);

          spec.change(() => Container.facade_resolver).to(resolver);

          return dependency;
        }
      }

      public static ContainerScaffold scaffold(IConfigureSpecifications spec, ICreateFakes fake)
      {
        return new ContainerScaffold(spec, fake);
      }
    }

    public class web
    {
      public static HttpContext create_http_context()
      {
        return new HttpContext(create_request(), create_response());
      }

      static HttpResponse create_response()
      {
        return new HttpResponse(new StringWriter());
      }

      static HttpRequest create_request()
      {
        return new HttpRequest("blah.aspx", "http://localhost/blah.aspx", String.Empty);
      }
    }
  }
}