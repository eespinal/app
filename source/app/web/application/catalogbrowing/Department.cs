namespace app.web.application.catalogbrowing
{
  public class Department
  {
    public string name { get; set; }
    public long id { get; set; }
    public bool has_products { get; set; }
    public bool has_sub_departments { get; set; }
  }

  public class Product
  {
    public string name { get; set; }
  }
}