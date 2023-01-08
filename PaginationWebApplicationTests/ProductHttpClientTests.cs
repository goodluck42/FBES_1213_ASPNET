using Microsoft.Extensions.DependencyInjection;

using Moq;

using PaginationWebApplication.Services;

using System.Linq;

namespace PaginationWebApplicationTests;


[TestClass]
public class ProductHttpClientTests
{
    public static IServiceCollection Services { get; set; } = null!;

    private readonly Mock<ProductHttpClient> _mockClient;

    public ProductHttpClientTests()
    {
        _mockClient = new Mock<ProductHttpClient>();
    }

    [TestMethod]
    public async Task TestProductQuantity()
    {
        var returns = It.Is<List<Product>>(products => products.All(p => p.Quantity >= 0));

        _mockClient.Setup(client => client.GetProductsAsync()).ReturnsAsync(returns);

        //var result = await _mockClient.GetProductsAsync();

        //Assert.IsNotNull(result);

        //foreach (var product in result)
        //{
        //    if (product.Quantity < 0)
        //    {
        //        Assert.Fail();
        //    }
        //}
    }


}