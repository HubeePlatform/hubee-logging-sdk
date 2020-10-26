# Hubee Logging Sdk

![N|Solid](https://media-exp1.licdn.com/dms/image/C4E0BAQHOp41isf2byw/company-logo_200_200/0?e=1611792000&v=beta&t=R627Tkw1cwQgb-LjNTJh_4auJWQsQieuU4wHoyLfIDA)

Hubee Logging Sdk é uma biblioteca que faz abstração da implementação com outras bibliotecas de log do mercado para aplicativos .NET. A principal ideia desse SDK é abstrair toda a complexidade das configurações e ser adaptável para as mudanças de tecnologias, centralizando toda manutenção e evolução em um único ponto.

## Bibliotecas Implementadas

- Serilog
  - Console
  - Graylog

## Getting started

O Hubee Logging Sdk é instalado a partir do NuGet (Package source: GitHub), segue abaixo o comando para a instalação via CLI:

```bash
dotnet add PROJECT package Hubee.Logging.Sdk --version 0.0.x
```

Após realizar a instalação podemos iniciar a configuração para utilizar o SDK, segue abaixo a configuração que deve ser realizada na seção "HubeeLoggingConfig" dentro do arquivo appsettings:

```json
  "HubeeLoggingConfig": {
    "ApplicationName": "Nome da aplicação",
    "LibraryType": "Serilog",
    "ProviderType": "Graylog",
    "Host": "localhost",
    "Port": ""
  }
```

Depois da configuração acima deve-se adicionar o SDK na aplicação,
segue abaixo a linha de código que deve ser adicionada no arquivo "Program.cs":

```csharp
public static IWebHostBuilder CreateWebHostBuilder(string[] args, IConfigurationRoot configuration) =>
    WebHost.CreateDefaultBuilder(args)
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseConfiguration(configuration)
        .UseStartup<Startup>()
        .UseHubeeLogging(configuration); // Adicionando SDK
```

Pronto, finalizamos todas as configurações necessárias e agora podemos utilizar os logs na aplicação.

### Exemplos de utilização

#### Inicialização da instância do log (microsoft.logging.extensions)

```csharp
public class ExemploLog
{
  private readonly ILogger<ExemploLog> _logger;

  public ExemploLog(ILogger<ExemploLog> logger)
  {
    _logger = logger;
  }
}
```

#### Exemplo

```csharp
_logger.LogInformation("Registrando informações");
```

#### Exemplo com JSON

```csharp
var jsonString = JsonSerializer.Serialize(object);
_logger.LogInformation("Registrando {nome} com valor json: {json}", "exemplo", jsonString);
```

#### Exemplo com Exception

```csharp
try
{
  //Implementação
}
catch (Exception ex)
{
  _logger.LogError(ex, ex.Message, ex.StackTrace);
}
```
