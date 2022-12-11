using ASPNET_HTML_HELPERSApplication.Models;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

using System.Text.Encodings.Web;

namespace ASPNET_HTML_HELPERSApplication.TagHelpers
{
	[HtmlTargetElement("products", Attributes = "product-list, product-count", TagStructure = TagStructure.NormalOrSelfClosing)]
	public class ProductListTagHelper : TagHelper
	{
		[HtmlAttributeName("product-list")]
		public IEnumerable<Product>? Products { get; set; }

		[HtmlAttributeName("product-count")]
		public int Count { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "ul";
			output.AddClass("test", HtmlEncoder.Default);

			if (Products == null)
			{
				return;
			}

			foreach (var product in Products)
			{
				var tagBuilder = new TagBuilder("li");

				tagBuilder.InnerHtml.Append($"{product.Name}[{product.Quantity}]:{product.Id}");

				output.Content.AppendHtml(tagBuilder);
			}
		}
	}
}
