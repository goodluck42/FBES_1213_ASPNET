namespace ASP_DI_WebApplication.Services
{
	public class GuidService : IGuidService
	{
		public GuidService()
		{
			Guid = System.Guid.NewGuid().ToString();
		}

		public string Guid { get; }
	}
}
