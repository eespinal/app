using System;
using System.Collections;
using System.Collections.Generic;
using Machine.Specifications;
using app.tasks.startup;
using app.utility.containers.basic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(CreateStartupSteps))]
  public class CreateStartupStepsSpecs
  {
    public abstract class concern : Observes<ICreateStartupSteps,
                                      CreateStartupSteps>
    {
    }

    public class when_creating_an_startup_step : concern
    {
      public class and_it_follows_the_convention
      {
        Establish context = () =>
        {
          provide_startup_facilities = new FakeFacility();
          depends.on(provide_startup_facilities);
        };

        Because b = () =>
          result = sut.create_from(typeof(Step));

        It should_return_an_instance_of_the_step = () =>
          result.ShouldBeAn<Step>().facilities.ShouldEqual(provide_startup_facilities);

        static IRunAStartupStep result;
        static IProvideStartupFacilities provide_startup_facilities;
      }

      public class and_it_does_not_follow_the_convention
      {
        Establish context = () =>
        {
          exception = new Exception();
          provide_startup_facilities = new FakeFacility();
          depends.on<StartupConventionNotFollowedExceptionFactory>(x =>
          {
            x.ShouldEqual(typeof(BadStep));
            return exception;
          });
          depends.on(provide_startup_facilities);
        };

        Because b = () =>
          spec.catch_exception(() => sut.create_from(typeof(BadStep)));

        It should_throw_the_exception = () =>
          spec.exception_thrown.ShouldEqual(exception);


        static IRunAStartupStep result;
        static IProvideStartupFacilities provide_startup_facilities;
        static Exception exception;
      }

      public class Step : IRunAStartupStep
      {
        public IProvideStartupFacilities facilities;

        public Step(IProvideStartupFacilities facilities)
        {
          this.facilities = facilities;
        }

        public void run()
        {
        }
      }

      public class BadStep : IRunAStartupStep
      {
        public void run()
        {
          throw new NotImplementedException();
        }
      }
    }
  }

  class FakeFacility : IProvideStartupFacilities
  {
    public IEnumerator<ICreateASingleDependency> GetEnumerator()
    {
      yield break;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public void register_factory_for<Contract, Implementation>() where Implementation : Contract
    {
      throw new NotImplementedException();
    }

    public void register_factory_for<Contract>()
    {
      throw new NotImplementedException();
    }

    public void register_instance_for<Contract>(Contract instance)
    {
      throw new NotImplementedException();
    }
  }
}