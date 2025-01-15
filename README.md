# RecordShop

## Context

The project was written as a learning exercise as part of the [Northcoders](https://northcoders.com/) bootcamp, specifically:

- ASP.NET Core
- SQLServer

## Running

1. Clone or download the repository.
2. `cd` into the repo folder:

```
cd cs-record-shop
```

3. `cd` into the `RecordShop` project.

```
cd RecordShop
```

4. Run the project:

```
dotnet run
```

This will build and run the project. Among the messages that appear, will be one providing the address on which the server is listening, e.g.:

```
info:   Microsoft.Hosting.Lifetime[14]
        Now listening on: http://localhost:<PORT> 

```

## Accessing in a browser 

5. In a browser, navigate to:

```
http://localhost:<PORT>/Albums
```

This will display a list of albums in the database. Using the browser alone it will only be possible to _access_ data in the database: it will not be possible to _modify_ the data.

## Accessing via the Swagger interface

5. In a browser, navigate to:

```
http://localhost:<PORT>/swagger/index.html
```

This will provide the possibility of submitting the full range of GET, POST, PUT and DELETE requests. 

# Dependencies and licenses

The main project has no third-party dependencies beyond those required for ASP.NET and Entity Framework (working with SQLServer).

The test project depends on:
- [NUnit](https://github.com/nunit/nunit) ([MIT](https://github.com/nunit/nunit?tab=MIT-1-ov-file#readme))
- [Moq](https://github.com/devlooped/moq) ([BSD-3](https://github.com/devlooped/moq?tab=License-1-ov-file#readme))
- [Coverlet](https://github.com/coverlet-coverage/) ([MIT](https://github.com/coverlet-coverage/coverlet?tab=License-1-ov-file))

For license text, see under `LICENSES/`.