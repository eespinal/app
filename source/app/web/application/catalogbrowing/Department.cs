namespace app.web.application.catalogbrowing {
	public class Department
	{
		public int id { get; set; }
		public string name { get; set; }
	}

	public class SubDepartment : Department
	{
		public int parent_id { get; set; }
	}
}