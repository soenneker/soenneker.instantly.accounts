using FluentAssertions;
using Soenneker.Facts.Local;
using Soenneker.Instantly.Accounts.Abstract;
using Soenneker.Tests.FixturedUnit;
using System.Threading.Tasks;
using Soenneker.Instantly.Accounts.Responses;
using Xunit;
using Xunit.Abstractions;

namespace Soenneker.Instantly.Accounts.Tests;

[Collection("Collection")]
public class InstantlyAccountsUtilTests : FixturedUnitTest
{
    private readonly IInstantlyAccountsUtil _util;

    public InstantlyAccountsUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IInstantlyAccountsUtil>(true);
    }

    [LocalFact]
    public async Task GetList_should_get_accounts()
    {
        InstantlyAccountsResponse? response = await _util.GetAllAccounts();
        response.Should().NotBeNull();
    }
}
