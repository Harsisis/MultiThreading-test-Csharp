/*using FastEndpoints;
using Microsoft.AspNetCore.Builder;

var bld = WebApplication.CreateBuilder();
bld.Services.AddFastEndpoints();

var app = bld.Build();
app.UseFastEndpoints();
app.Run();
*/


using System.Diagnostics;
using TaskTest;

var timer = new Stopwatch();
timer.Start();
//First sample using async and await, both calls are waited but done in the same time
await SimpleAsyncUsage.SimpleAsyncCall();
timer.Stop();
Console.WriteLine("{0} Elapsed time SimpleAsyncCall", timer.ElapsedMilliseconds.ToString());

//Second sample comparing time of 4 different usage of async

/*//// Version 4
Console.WriteLine("Fourth way to use Async");
timer.Reset();
timer.Start();
Console.WriteLine("RandomNumber-UpperString : {0}", await WaysToUseAsync.DoTasksV4("Some string"));
timer.Stop();
Console.WriteLine("{0} Elapsed time V4", timer.Elapsed.ToString());
*/

////Version 5
Console.WriteLine("Fifth way to use Async");
timer.Reset();
timer.Start();
Console.WriteLine("RandomNumber-UpperString : {0}", await WaysToUseAsync.DoTasksV5("Some string"));
timer.Stop();
Console.WriteLine("{0} Elapsed time V5", timer.Elapsed.ToString());