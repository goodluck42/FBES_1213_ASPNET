using System.Collections;

namespace ASP_DI_WebApplication.Services
{
	public class CounterService : ICounterService
	{
		private readonly IGuidService _guidService;
		public CounterService(IGuidService guidService)
		{
			Counter = Random.Shared.Next(0, 100);
			_guidService =	guidService;
		}

		public int Counter { get; }

		public override string ToString()
		{
			return $"{_guidService.Guid} : {Counter}";
		}
	}
	
	public class CounterService1000 : ICounterService
	{
		public CounterService1000()
		{
			Counter = Random.Shared.Next(0, 1000);
		}

		public int Counter { get; }
	}
	
	public class CounterService1000000 : ICounterService
	{
		public CounterService1000000()
		{
			Counter = Random.Shared.Next(0, 1000000);
		}

		public int Counter { get; }
	}
}
