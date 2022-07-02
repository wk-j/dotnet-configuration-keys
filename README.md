## Replace all configuration with Keys section

[![Actions](https://github.com/wk-j/dotnet-keys-configuration/workflows/Build/badge.svg)](https://github.com/wk-j/dotnet-keys-configuration/actions)
[![NuGet](https://img.shields.io/nuget/v/wk.KeysConfiguration.svg)](https://www.nuget.org/packages/wk.KeysConfiguration)
[![NuGet Downloads](https://img.shields.io/nuget/dt/wk.KeysConfiguration.svg)](https://www.nuget.org/packages/wk.KeysConfiguration)
[![NuGet](https://buildstats.info/nuget/wk.KeysConfiguration)](https://www.nuget.org/packages/wk.KeysConfiguration)

```
dotnet add src/MyWeb package wk.KeysConfiguration
```

## Usage

### Register

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddKeysConfiguration(sectionName: "Keys");
```

### Update `appsettings.json`

```json
{
  "Service1": "http://@Host:@Port/service1",
  "Service2": "http://@Host:@Port/service2",
  "Keys": {
    "@Host": "localhost",
    "@Port": "8080"
  }
}
```