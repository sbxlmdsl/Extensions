# Genesys Source Extensions
Genesys Source Extensions is an open-source, cross-platform library that extends the .NET Framework, and brings extra .NET-level and functionality. 

Bringing reusability to your software stack without the cost and uncertainty.

Projects:
* Genesys.Extensions.Core: Portable Class Library (Windows, Xamarin iOS, Xamarin Android), .NET 4.6, Profile 151
* Genesys.Extensions.Standard: Class Library .NET 4.6
* Genesys.Extras.Core: Portable Class Library (Windows, Xamarin iOS, Xamarin Android), .NET 4.6, Profile 151
* Genesys.Extras.Standard: Class Library .NET 4.6

Database:
* SQL Express database included: Genesys.Extensions.Test\App_Data\GenesysExtensionsTest.mdf
 
Genesys Source Namespaces:
* Genesys.Framework: Structure and functionality Framework to support your reusable entities. Classes such as CrudEntity, EntityReader and EntityWriter.
* Genesys.Extensions: .NET Framework extension methods for null-safe, strongly-typed operations. Cross-platform, open-source common library for .NET.Standard and .NET Core (Universal, Portable).
* Genesys.Extras: .NET Framework-level classes for common tasks such as Http request/response, serialization, string manipulation, error logging, etc. Cross-platform, open-source common library.

### Reference Site and Documentation
Genesys Source Framework downloads and docs available at [GenesysFramework.com](http://www.GenesysFramework.com):
Genesys Source Framework...
* [Genesys Framework Overview](http://www.getframework.com/)
* [Genesys Framework Quick-Guide](http://docs.genesyssource.com/library/Genesys-Framework/Genesys-Framework-Quick-Guide.pdf)
* [Genesys Framework Requirements](http://docs.genesyssource.com/library/Genesys-Framework/Genesys-Framework-Requirements.pdf)
* [Genesys Framework Reference](http://docs.genesyssource.com/reference/Genesys-Framework)
Genesys Soruce Extensions...
* [Genesys Extensions Reference ](http://docs.genesyssource.com/reference/Genesys-Extensions)

### Dev Environment and Compiling
Please use the latest Visual Studio and build using the IDE or MSBuild.exe. Our CICD processes default to the latest Visual Studio and MSBuild versions.

### Database Environment and Publishing
Please use the latest SQL Server and/or SQL Expresss and publish using the SSDT project Framework.Database.

### Hosting
- Cloud: Azure Web Server, Database Server and/or Virtual Machines.
- On-Prem: Latest Windows Server, IIS, .NET 4.5, SQL Server.

### Build and Release
- VisualStudio.com repos set to TFVC. On-prem TFS server and build agent for local infrastructure powershell deployments.
- Local NuGet feed for development cycles.
- Sprints pushed to GitHub on or about the 7th of each month.

### Git Repo for Genesys Source Extensions
- [https://github.com/GenesysSource/Extensions.git](https://github.com/GenesysSource/Extensions.git)
- `git clone git@github.com:GenesysSource/Extensions.git`