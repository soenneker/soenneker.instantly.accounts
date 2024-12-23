using Soenneker.Instantly.Accounts.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Instantly.Accounts.Tests;

[Collection("Collection")]
public class InstantlyAccountsUtilTests : FixturedUnitTest
{
    private readonly IInstantlyAccountsUtil _util;

    public InstantlyAccountsUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IInstantlyAccountsUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
