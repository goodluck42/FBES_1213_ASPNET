using ASPNET_HTML_HELPERSApplication.Models;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Text;
using System.Text.Encodings.Web;

namespace ASPNET_HTML_HELPERSApplication.HtmlHelpers;

public static class UnorderedListHelper
{
	public static HtmlString RenderProducts(this IHtmlHelper source, IEnumerable<Product> products)
	{
		// #2
		var builder = new TagBuilder("ul")
		{
			TagRenderMode = TagRenderMode.Normal
		};

		builder.GenerateId("product#list", "_");
		builder.AddCssClass("product-list");
		builder.Attributes.Add("data-count", products.Count().ToString());

		foreach (var product in products)
		{
			var tag = new TagBuilder("li");

			tag.InnerHtml.Append($"{product.Name}[{product.Quantity}]:{product.Id}");

			builder.InnerHtml.AppendHtml(tag);
		}

		using var writer = new StringWriter();

		builder.WriteTo(writer, HtmlEncoder.Default);


		return new HtmlString(writer.ToString());

		// #1
		//var builder = new StringBuilder();

		//builder.Append("<ul>");

		//foreach (var product in products)
		//{
		//	builder.Append($"<li>{product.Name}[{product.Quantity}]:{product.Id}</li>");
		//}

		//builder.Append("</ul>");

		//return new HtmlString(builder.ToString());
	}
}
