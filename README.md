# Simpel ekstra opgave til Prosa Udvidet C# forløb

Jeg har forsøgt at skabe en opgave som dækker nogle af de emner vi har været igennem i forløbet. Den tager udgangspunkt i vores tidligere ProsaApp-eksempel, som vi har arbejdet med i forløbet. Du skal ikke skrive meget kode, men du skal implementere nogle grundlæggende funktioner for at få applikationen til at fungere på en helt konkret måde.

## Hent repository

Det første du skal gøre er at downloade hele repositoriet. Du kan gøre dette ved at klone det med git eller downloade det som zip-fil (den store grønne knap). Hele løsningen pakkes ud i en temporær mappe - eksempelvis `c:\temp\prosa`.

Herefter kan du åbne mappen i Visual Studio Code (eller ProsaOpg.sln i Visual Studio eller Rider - her antages VSC). 

## Få det til at virke

- Først skal du installere .NET 9.0 SDK, hvis du ikke allerede har det installeret. Du kan finde installationsvejledningen [her](https://dotnet.microsoft.com/en-us/download/dotnet/9.0).
- Dernæst skal du åbne terminalen i Visual Studio Code og navigere til den mappe, hvor du har pakket løsningen ud. Du kan gøre dette ved at skrive `cd c:\temp\prosa` i terminalen.
- Når du er i den rigtige mappe, skal du køre kommandoen `dotnet restore` for at installere de nødvendige pakker.
- Herefter kan du bygge alle projekter ved at skrive `dotnet build` i terminalen. Den skulle gerne bygge uden fejl.
- Naviger nu til `ProsaOpg/ConsoleUI`og skriv `dotnet run` i terminalen. Du skulle gerne se `Hello, World - debug`. Prøv også at skrive `dotnet run -c Release` hvilke vil kompilere og afvikle koden i Release mode. Du skulle gerne se `Hello, World - Release`.
- Naviger nu til `ProsaOpg/ProsaOpg.Test` og skriv `dotnet test` i terminalen. Du skulle gerne se at alle tests (der er kun en lige nu) kører uden fejl. Prøv også `dotnet test -l "console;verbosity=detailed"` for at se mere detaljeret output fra testene.

## Kig på koden

- Når alt spiller kan du begynde at kigge på koden. 
- Bemærk at der er 4 projekter - ConsoleUI (brugerflade), Data (data og repository), Types (domæne typer) og Test (test). Sørg for at kigge grundigt på koden og forstå hvordan de forskellige projekter hænger sammen. Der er også en SQLite database `Customers.db` i `ConsoleUI` mappen, som indeholder nogle testdata.
    - I `Types` er en helt simpel klasse `Customer` defineret. 
    - I `Data` er der en interface `IDataAccess` defineret, som indeholder en metode til at hente kunder. Der er en `EfDataAccessService` (bruger EF til at hente data) og `MockDataAccessService` (statiske data) der implementerer interfacet. Der er også en `DataAccessFactory` der returnerer den rigtige data access service baseret på en konfiguration - her debug og release.
    - I `ConsoleUI` er der en `Program.cs` med en simpel "Hello World"
    - I `Test` er der en testklasse `AllTests` der her en helt simpel `IsCreatedDateCorrectWhenCreatingANewCustomer` der tester om `CreatedDate` er sat korrekt når en ny kunde oprettes - blot som et eksempel.

Projektstruktur:

```
- ProsaOpg/
  - ProsaOpg.sln (solution fil)
  - ConsoleUI/
    - Program.cs
    - Customers.db (SqLite database)
  - Data/
    - IDataAccess.cs
    - EfDataAccessService.cs
    - MockDataAccessService.cs
    - DataAccessFactory.cs
  - Types/
    - Customer.cs
  - Test/
    - AllTests.cs
```

## Skriv lidt kode

Ideen med datalaget er, at det skal være nemt at skabe en instans af `IDataAccess` og derefter kalde metoderne på den. Det er derfor vigtigt at du forstår hvordan `DataAccessFactory` fungerer, da det er den der skaber instanser af objekter som implementerer `IDataAccess` - og dermed kan tale med forskellige datakilder - herunder i dette tilfælde en database og en mock service.

Så dit job er at skrive lidt kode i `ConsoleUI` og `Test` projekterne, så du kan hente kunder fra databasen og vise dem i konsollen. Du skal også skrive en test der tester at kunderne bliver hentet korrekt fra databasen.

### ConsoleUI

I `ConsoleUI` skal du ændre `Program.cs` så den henter kunderne fra datakilden og viser dem i konsollen. Du skal bruge `DataAccessFactory` til at få fat i den rigtige instans af `IDataAccess` (hvis den kører i debug mode skal den hente fra `MockDataAccessService`, hvis den kører i release mode skal den hente fra `EfDataAccessService`). 

Så når du kører `dotnet run` i `ConsoleUI` skal den hente mock kunder vise dem i konsollen, og når du kører `dotnet run -c Release` skal den hente kunder fra databasen og vise dem i konsollen. Det kan skal se således ud:

```batch
dotnet run

Hello, World! - debug
Customer 1
Customer 2
Customer 3
Customer 4
Customer 5

dotnet run -c Release

Hello, World! - release
Emma Hansen
Lars Jensen
Nina Olsen
Erik Svensson
Anna Larsson
Morten Pedersen
Kari Nilsen
Olof Karlsson
Sofie Andersen
Henrik Johansen
Mia Berg
Johan Hansen
Ingrid Larsen
Fredrik Eriksson
Camilla Petersen
Ole Kristiansen
Sara Nilsson
Anders Madsen
Lene Olsen
Mikael Johansson
Aino Virtanen
Juhani Nieminen
Kaisa Korhonen
Mikko Laine
Liisa Heikkinen
Pekka Mäkelä
Sanna Salminen
Antti Koskinen
Marja Lehtinen
Jari Hämäläinen
```

### Test

I `Test` skal du skrive en test der tester at kunderne bliver hentet korrekt fra databasen. Du skal skrive en test der hedder `WhenUsingMockDataAccessServiceAreWeGettingFiveCustomers` og som tester at der bliver hentet 5 kunder fra mock-datakilden. Her kan du blot oprette en instans af `MockDataAccessService` og kalde `GetAllCustomers` metoden. Du kan derefter sammenligne antallet af kunder der bliver hentet med det forventede antal kunder (5).

Når du kører `dotnet test` i `Test` skal de (nu) 2 tests køre uden fejl og vise at alt er godt.

```batch
dotnet test -l "console;verbosity=detailed"    

Restore complete (0,6s)
  ProsaOpg.Types succeeded (0,1s) → C:\temp\prosa-opg\ProsaOpg.Types\bin\Debug\net9.0\ProsaOpg.Types.dll     
  ProsaOpg.Data succeeded (0,3s) → C:\temp\prosa-opg\ProsaOpg.Data\bin\Debug\net9.0\ProsaOpg.Data.dll
  ProsaOpg.Test succeeded (0,7s) → bin\Debug\net9.0\ProsaOpg.Test.dll
A total of 1 test files matched the specified pattern.
C:\temp\prosa-opg\ProsaOpg.Test\bin\Debug\net9.0\ProsaOpg.Test.dll
[xUnit.net 00:00:00.00] xUnit.net VSTest Adapter v2.8.2+699d445a1a (64-bit .NET 9.0.2)
[xUnit.net 00:00:00.00] xUnit.net VSTest Adapter v2.8.2+699d445a1a (64-bit .NET 9.0.2)
[xUnit.net 00:00:00.15]   Discovering: ProsaOpg.Test
[xUnit.net 00:00:00.15]   Discovering: ProsaOpg.Test
[xUnit.net 00:00:00.19]   Discovered:  ProsaOpg.Test
[xUnit.net 00:00:00.19]   Discovered:  ProsaOpg.Test
[xUnit.net 00:00:00.19]   Starting:    ProsaOpg.Test
[xUnit.net 00:00:00.19]   Starting:    ProsaOpg.Test
[xUnit.net 00:00:00.26]   Finished:    ProsaOpg.Test
[xUnit.net 00:00:00.26]   Finished:    ProsaOpg.Test
  Passed ProsaOpg.Test.AllTests.WhenUsingMockDataAccessServiceAreWeGettingFiveCustomers [15 ms]
  Passed ProsaOpg.Test.AllTests.IsCreatedDateCorrectWhenCreatingANewCustomer [< 1 ms]

Test Run Successful.
Total tests: 2
     Passed: 2
 Total time: 1,3580 Seconds
  ProsaOpg.Test test succeeded (2,0s)

Test summary: total: 2; failed: 0; succeeded: 2; skipped: 0; duration: 2,0s
Build succeeded in 4,4s
```

Bemærk at der køres to tests nu.

## Aflevering

Når du er færdig med opgaven skal enten sende mig et link til dit eget offentlige repository, hvor
du har uploadet løsningen - men du kan også bare sende mig en mail (michell@cronberg.dk) hvor du inkludere filerne Program.cs og AllTests.cs. Jeg behøver ikke de andre filer, da de ikke ændres.

Herefter kigger jeg på din løsning og sender dig feedback eller et bevis på at opgaven er bestået.