[![](https://img.shields.io/nuget/v/soenneker.instantly.accounts.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.instantly.accounts/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.instantly.accounts/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.instantly.accounts/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.instantly.accounts.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.instantly.accounts/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.instantly.accounts/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.instantly.accounts/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Instantly.Accounts

List Instantly sending accounts one page at a time or retrieve all pages as one result.

## Install

```bash
dotnet add package Soenneker.Instantly.Accounts
```

## Configure and register

```json
{
  "Instantly": {
    "ApiKey": "<API key>",
    "LogEnabled": false
  }
}
```

```csharp
using Soenneker.Instantly.Accounts.Registrars;

services.AddInstantlyAccountsUtilAsScoped();
```

The scoped accounts service deliberately uses the singleton generated-client provider. Use `AddInstantlyAccountsUtilAsSingleton()` when the operation layer should also live for the application lifetime.

## Get one page

```csharp
using Soenneker.Instantly.Accounts.Abstract;
using Soenneker.Instantly.OpenApiClient.Models;

ListAccount200Response? page = await accounts.GetList(
    limit: 50,
    skip: startingAfter,
    cancellationToken: cancellationToken);
```

When `limit` is omitted, `GetList` requests 10 accounts. `skip` is converted to UTC and sent as Instantly's `starting_after` timestamp cursor.

## Get every account

```csharp
ListAccount200Response allAccounts = await accounts.GetAllAccounts(
    cancellationToken: cancellationToken);
```

`GetAllAccounts` requests batches of 100 and follows `next_starting_after` until the API returns a short page or no next cursor. You can pass `startingAfter` to resume from a known timestamp. The returned response combines every retrieved page into `Items`.

API and deserialization failures are not suppressed. If Instantly repeats a pagination cursor, the method throws instead of looping indefinitely.
