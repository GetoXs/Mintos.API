# Mintos.API

A **.NET** library that calls the [Mintos](https://www.mintos.com/) API. It is **not** an official Mintos SDK or a product of the platform.

[![NuGet](https://img.shields.io/nuget/dt/Mintos.API.svg)](https://www.nuget.org/packages/Mintos.API) 
[![NuGet](https://img.shields.io/nuget/vpre/Mintos.API.svg)](https://www.nuget.org/packages/Mintos.API)
[![license](https://img.shields.io/github/license/GetoXs/Mintos.API.svg)](https://github.com/GetoXs/Mintos.API/blob/master/LICENSE.txt)

---

## ⚠️ Legal notice and liability

- **Mintos Terms and Conditions** prohibit bots, scripts, and other automation that conflicts with platform rules. Using this library for automation may **violate those terms**.
- This repository is for educational and technical purposes only. **You use it at your own risk**, including any legal consequences, account suspension, or loss of funds.
- Authors and contributors **accept no liability** for how this code is used.

---

## Features

- Session via cookies (`MW_SESSION_ID`, `PHPSESSID`) and `anti-csrf-token` header
- Session refresh (`RefreshSessionAsync`)
- User profile, balance, currency overview, portfolio distribution
- Primary and secondary markets (note series)
- Current and finished note-series investments
- Cart: secondary shares and primary notes — add, list, clear, confirm share purchase
- Retry on `401`/`403` via `OnUnauthorizedAsync` (e.g. refresh credentials)

---

## Requirements

- Target **.NET 10** or later (same major as the package)
- `Microsoft.Extensions.Logging.Abstractions` is referenced by the package; you do not add it manually unless you need a specific version

---

## Install and quick start

**1. Add the NuGet package** to your app:

```bash
dotnet add package Mintos.API
```

**2. Create the client and call the API**:

```csharp
using Mintos.API;
using Microsoft.Extensions.Logging;

using var proxy = new MintosProxyApi(NullLogger<MintosProxyApi>.Instance);
var client = new MintosClient(proxy, NullLogger<MintosClient>.Instance);
// Obtain values from **your own** logged-in browser session
client.Initialize(mwSessionId, phpSessionId, antiCsrfToken);
var user = await client.GetUserAsync();
```

Optionally set `proxyApi.OnUnauthorizedAsync` to refresh credentials and retry when the session expires.

---

## Build and pack (from source)

```bash
dotnet build src/Mintos.API.sln
dotnet pack src/Mintos.API/Mintos.API.csproj -c Release
```

Produces a `.nupkg` under `src/Mintos.API/bin/Release/` (or `Debug`) for publishing to a feed.

---

## License

See [LICENSE.txt](LICENSE.txt).

---

## Trademark disclaimer

“Mintos” is a trademark of its owner. This project is not affiliated with or endorsed by Mintos.