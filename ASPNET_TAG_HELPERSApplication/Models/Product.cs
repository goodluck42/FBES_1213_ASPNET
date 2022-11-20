using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace ASPNET_HTML_HELPERSApplication.Models;


[Index("Name", IsUnique = true)]
public class Product
{
	[Key]
	public int Id { get; set; }

	[MaxLength(450)]
	public string Name { get; set; }

	[Required]
	public int Quantity { get; set; }
}
