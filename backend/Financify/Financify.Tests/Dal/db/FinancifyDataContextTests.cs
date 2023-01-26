using Financify.Tests.Dal.Basics;

namespace Financify.Tests.Dal.db;

public class FinancifyDataContextTests : FinancifyDataContextTestBase
{
    [Fact]
    public void FinancifyDataContextCreated()
    {
        Assert.NotNull(Context);
    }

    [Fact]
    public void FinancifyDataContextCanConnect()
    {
        Assert.True(Context.Database.CanConnect());
    }
}