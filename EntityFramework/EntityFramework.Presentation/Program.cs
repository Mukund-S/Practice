// See https://aka.ms/new-console-template for more information

using EntityFramework.UI;
using Serilog;
using Serilog.Core;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File("Logs/mylog.txt")
    .CreateLogger();
Log.Information("Application Started");
Log.Debug("This is a debug message");


//Controller --> Services(Business Logic) --> Repositories(Will talk to DB) --> Data Access Layer(Entity Framework/Dapper)


 ManageDepartment _manageDepartment = new ManageDepartment();
 _manageDepartment.Run();

//RequestModel --> Entity(for request from users)
// Entity --> ResponseModel(for response from the database)
//ResponseModel -->
// try
// {
//     ManageEmployee manageEmployee = new ManageEmployee();
//     manageEmployee.Run();
//
// }
// catch (Exception e)
// {
//     Log.Warning("An unexpected warning occured.");
//     Log.Error("An error occurred while processing");
//     Log.Fatal("An error has occurred and is fatal.");
//     Console.WriteLine(e);
//     throw;
// }

/*
 * Logging: SeriLog : Third Party property for logging
 * Nuget: Serilog.Sinks.File
 *
 * Homework:
 * Service Layer for Department
 * Include Range of Methods
 * 
 */