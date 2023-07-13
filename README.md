# HG.EasyDi

🧩 HG.EasyDi is a lightweight dependency injection library for ASP.NET Core.

## Features

✨ Easy integration with ASP.NET Core applications.

✨ Attribute-based service registration.

✨ Support for singleton, scoped, and transient lifetimes.

✨ Automatic scanning of namespaces for service registration.

## 🔥 Installation

You can install the HG.EasyDi package via NuGet package manager or by adding it directly to your project file.

```bash
dotnet add package HG.EasyDi
```
# 🪧 Usage
Define your services and interfaces:
```C#
public interface ISampleService
{
    void DoSomething();
}

[EasyDi(ServiceLifetime.Singleton)]
public class SampleService : ISampleService
{
    public void DoSomething()
    {
        // Implementation code here
    }
}
```

Register services in your Program.cs file:

Full Scan:
```C#
builder.Services.AddEasyDi();
```
Scan special namespace:
```C#
builder.Services.AddEasyDi(o=>o.SetNamespaceRootToScan("HG.EasyDi.PlantTest.Service"));
```
Inject and use the services in your controllers or other classes:
```C#
public class SampleController : ControllerBase
{
    private readonly ISampleService _sampleService;

    public SampleController(ISampleService sampleService)
    {
        _sampleService = sampleService;
    }

    // Controller actions
}
```
