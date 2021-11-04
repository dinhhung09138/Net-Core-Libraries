# How to use Serilog

### Installation 

Install these packages:
>Serilog.AspNetCore
>Serilog.Settings.Configuration

### Write log to Console
Install this package
>Serilog.Sinks.Console

appsettings.json
>"Serilog": {
>    "MinimumLevel": "Information",
>    "WriteTo": [
>      {
>        "Name": "Console",
>        "Args": {
>          "outputTemplate": "{Timestamp:dd/MM/yyyy hh:mm:ss} [{Level}] [{SourceContext}] [{EventId}] {Message} {NewLine} {Exception}"
>        }
>      }

### Write log to specific file 
Install this package
>Serilog.Sinks.File

appsettings.json
> "Serilog": {
>    "MinimumLevel": "Information",
>    "WriteTo": [
>      {
>        "Name": "File",
>        "Args": {
>          "path": "Logs/Logfile.log",
>          "outputTemplate": "{Timestamp:dd/MM/yyyy hh:mm:ss} [{Level}] [{SourceContext}] [{EventId}] {Message} {NewLine} {Exception}"
>        }
>      }
>    ]
>  }

## Write log to roll file (Format file name)
Install this package
>Serilog.Sinks.RollingFile

appsettings.json
>"Serilog": {
>    "MinimumLevel": "Information",
>    "WriteTo": [
>      {
>        "Name": "RollingFile",
>        "Args": {
>          "pathFormat": "Logs/log-{Date}.txt",
>          "outputTemplate": "{Timestamp:dd/MM/yyyy hh:mm:ss} [{Level}] [{SourceContext}] [{EventId}] {Message} {NewLine} {Exception}"
>        }
>      }
>    ]
>  }


### How to implement in Net 5

**program.cs**
using Serilog
> using Serilog;

Update the method **CreateHostDefaultBuilder**
> Host.CreateDefaultBuilder(args).UseSerilog()

Add more codes inside the **Configure** method in **Startup.cs**
> var configuration = new ConfigurationBuilder()
                                    .SetBasePath(env.ContentRootPath)
                                    .AddJsonFile("appsettings.json", true, true)
                                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                                    .AddEnvironmentVariables()
                                    .Build();

> Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
> //Test create log
> Log.Information("Start logger");

## How to implement in Net 6
using Serilog
> using Serilog;
> var configuration = new ConfigurationBuilder()
                        .SetBasePath(app.Environment.ContentRootPath)
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings{app.Environment.EnvironmentName}.json", true, true).AddEnvironmentVariables()
                        .Build();

> Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();


