# Preparation for Exam 70-487: Developing Microsoft Azure and Web Services

Blog post that will take you through the specifics of this project:
https://hendrikbulens.wordpress.com/2016/06/04/preparation-guide-for-exam-70-487-developing-microsoft-azure-and-web-services/

### Prerequisites ##

This solution was created using Visual Studio 2015 RC3. 
You may need to install the following items:
- SQL Server Data Tools to use the database project inside the solution.
- ASP.NET Core 1.0.0.0
- Azure SDK 2.9

To run the console applications hosting WCF (Data) Services, you may need to do so with administrative privileges.
You also need a SQL Server database to run the samples.

### Solution ###

The solution is divided into several folders, therefore grouping it into logical sets of projects:
- Azure: contains the assemblies that use the Windows Azure platform
- Utilities: assemblies supporting the other projects in the solution
- WCF: projects hosting and consuming WCF Services and WCF Data Services
- Web APi: projects hosting and consuming Web API services
- Cache: projects hosting and consuming Memory Cache services and code

Both Web API and WCF service projects are self-hosted console applications, so in order to consume these services you need to run these first:
- hbulens.Exam70487.WebApi
- hbulens.Exam70487.Wcf
- hbulens.Exam70487.Wcf.Duplex
- hbulens.Exam70487.WcfData

The consuming counterparts are console applications that call the exposed services:
- hbulens.Exam70487.WebApi.Client
- hbulens.Exam70487.Wcf.Client
- hbulens.Exam70487.Wcf.Duplex.Client
- hbulens.Exam70487.WcfData.Client

Ultimately, there is an ASP.NET Core application that combines all these together. If you want to run all samples, you need to run all hosts at the same time.

### Running the sample ###
To run the sample, see the prerequisites. 

There is also a SQL Server Data Tools project in the solution that contains the database schema for the application. Use the schema compare tool to update the schema. Finally, the post deployment script has some sample data that you can use.

[![Demo CountPages alpha](https://gifs.com/gif/qxE82k)](https://www.youtube.com/watch?v=ek1j272iAmc)
[![Demo CountPages alpha](http://share.gifyoutube.com/KzB6Gb.gif)]

