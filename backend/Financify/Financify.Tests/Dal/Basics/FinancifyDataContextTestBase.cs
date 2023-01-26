using Financify.Dal.db;
using Microsoft.EntityFrameworkCore;

namespace Financify.Tests.Dal.Basics;

public abstract class FinancifyDataContextTestBase : IDisposable
{
    protected readonly FinancifyDataContext Context;

    protected FinancifyDataContextTestBase()
    {
        var options = new DbContextOptionsBuilder<FinancifyDataContext>()
            .UseInMemoryDatabase("Financify")
            .Options;

        Context = new FinancifyDataContext(options);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing) Context.Dispose();
    }
}