using Soenneker.Instantly.Accounts.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Instantly.Accounts.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class InstantlyAccountsUtilTests : HostedUnitTest
{
    private readonly IInstantlyAccountsUtil _util;

    public InstantlyAccountsUtilTests(Host host) : base(host)
    {
        _util = Resolve<IInstantlyAccountsUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
