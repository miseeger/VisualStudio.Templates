# VisualStudio.Templates



##  ![image](https://raw.githubusercontent.com/miseeger/VisualStudio.Templates/master/Sources/AspDotNet%20Core%20WinAuth%20WebApi%20NgClient/NgWebApp.png) ASP.NET Core Angular App with WebAPI

A template generating a quickstart-/boilerplate-project to be hosted on IIS, powered by ASP.NET Core 3.1, using Windows Authentication. The ClientApp is built with Angular 8 and consumes the WebAPI built with ASP.NET Core.

The project also contains a ready-to-use [NPoco](https://github.com/schotime/NPoco) data service for SQLite.



##  ![image](https://raw.githubusercontent.com/miseeger/VisualStudio.Templates/master/Sources/AspDotNet%20Core%20WinAuth%20WebApi%20PrimeNgClient/PrimeNgWebApp.png) ASP.NET Core PrimeNG Angular App with WebAPI

A template generating a boilerplate-project to be hosted on IIS, powered by ASP.NET Core 3.1, using Windows Authentication. The ClientApp is built with Angular 9 and consumes the WebAPI built with ASP.NET Core.

The underlying database is accessed by using EF Core. Code for the data tier is partly taken/adapted from the project [ChinookASPNETCoreAPINTier](https://github.com/cwoodruff/ChinookASPNETCoreAPINTier).



> ### Getting started with any of the above Angular projects (VS 2019)
>
> - Download the template's ZIP-file and save it in your VS project template folder.
>
> - Start VS and choose Create a new project (look for `C#` / `Windows` / `Angular` or search for `PrimeNG`) .
>
> - Select the "ASP.NET Core 3.1 WebAPI with PrimeNG Angular SPA Template". Click `Next`
>
> - Input project name and choose location. Click `create`.
>
> - When the project is created,  open a console window (CMD) and go to `path\to\your\<project>\<project>.Web\ClientApp`. Execute the following:
>
>    ```
>    > npm install
>    ```
>
>    ```
>    > npm start
>    ```
>
>    The latter precompiles the app in order to "optimize" further starts from VS.
>
> - When the dev server is startet, hit `CTRL+C` in order to cancel.
>
> - Close the console window
>
> - Make the `<project>.Web` project your startup project and start it from VS as usual.



## ![](https://raw.githubusercontent.com/miseeger/VisualStudio.Templates/master/Sources/Autofac%20Multi%20Application%20Solution/AfMulti.png "") Autofac Multi Application Solution    

A template generating a quickstart-/boilerplate-solution providing a framework for a modular 
multi-application solution, relying on the same service base. It excessively uses Autofac for 
IoC and the `AutofacModularity` library to extend modularity.

Refer to the [AutofacModularity repository](https://github.com/miseeger/AutofacModularity) to get further information. 



## ![image](https://raw.githubusercontent.com/miseeger/VisualStudio.Templates/master/Sources/Nancy%202%20Self%20Hosted%20WinAuth%20Web%20API%20Service/NancyTemplateIcon.png) Nancy 2 Self Hosted WinAuth Web API Service    

A template generating a quickstart-/boilerplate-project to self-host a Web API powered by Nancy 2, using Windows Authentication. It uses ASP.NET Core 2.0 and the server-library [HTTP.SYS](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/httpsys) *instead* of [WebListener](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/weblistener) which is used with ASP.NET Core 1.x.

The project also contains a ready-to-use [NPoco](https://github.com/schotime/NPoco) data service.

This template is heavily based on the Microsoft documentaion on how to [host an ASP.NET Core app in a Windows Service](https://docs.microsoft.com/en-us/aspnet/core/hosting/windows-service). 



## Further Templates

This repo also contains some Vue boilerplate templates:

- ASP.NET Core Vue App with WebAPI, Windows authorization and EF-Core (simple)
- ASP.NET Core Vue App with WebAPI, JWT authorization and EF-Core
- ASP.NET Core Vue App with SignalR, WebAPI, JWT authorization and EF-Core