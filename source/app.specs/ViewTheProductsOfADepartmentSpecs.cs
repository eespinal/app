using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewSubDepartments))]
  public class ViewTheProductsOfADepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAStory, ViewTheProductsOfADepartment>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        display_engine = depends.on<IDisplayReports>();
        current_department = new Department();
        the_request = fake.an<IProvideDetailsToCommands>();
        entities_repository = depends.on<IFindInformationInTheStore>();
        products = new List<Product> {new Product()};
        entities_repository.setup(x => x.get_products_of(current_department)).Return(products);

        the_request.setup(x => x.map<Department>()).Return(current_department);
      };

      Because b = () =>
        sut.process(the_request);

      It should_display_the_products = () =>
        display_engine.received(x => x.display(products));

      static IProvideDetailsToCommands the_request;
      static IDisplayReports display_engine;
      static Department current_department;
      private static IEnumerable<Product> products;
      private static IFindInformationInTheStore entities_repository;
    }
  }
}