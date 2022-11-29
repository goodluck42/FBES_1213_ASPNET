namespace AjaxWebApplication.Models
{
	public class Car
	{
		public int? Id { get; set; }
		public string Model { get; set; } = null!;
		public int Speed { get; set; }
		public int Price { get; set; }

		public void Update(Car car)
		{
			Model = car.Model;
			Speed = car.Speed;
			Price = car.Price;
		}
	}
}