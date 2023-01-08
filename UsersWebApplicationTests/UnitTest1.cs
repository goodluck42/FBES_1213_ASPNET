using UsersWebApplication.Services;

namespace UsersWebApplicationTests;

[TestClass]
public class TokenGeneratorTests
{
    private readonly UserTokengenerator _userTokengenerator;

    public TokenGeneratorTests()
    {
        _userTokengenerator = new UserTokengenerator();
    }

    [TestMethod]
    [DataRow("Test")]
    [Timeout(TestTimeout.Infinite)]
    public void TokenTest(string name)
    {
        var result = _userTokengenerator.Generate(new WebApiLibrary.User()
        {
            FirstName = name,
        });

        if (result.Length <= 32)
        {
            Assert.Fail();
        }
    }
}