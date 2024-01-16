using System.Diagnostics;
using TaskTest;

var timer = new Stopwatch();
/*timer.Start();
//First sample using async and await, both calls are waited but done in the same time
await SimpleAsyncUsage.SimpleAsyncCall();
timer.Stop();
Console.WriteLine("{0} Elapsed time SimpleAsyncCall", timer.ElapsedMilliseconds.ToString());*/

/*timer.Reset();*/
/*timer.Start();
Console.WriteLine("RandomNumber-UpperString : {0}", await WaysToUseAsync.DoTasksV5("Some string"));
timer.Stop();
Console.WriteLine("{0} Elapsed time V5", timer.Elapsed.ToString());*/


/*timer.Reset();
timer.Start();
await WaysToUseAsync.DoTasksContinueWith();
timer.Stop();
Console.WriteLine("{0} DoTasksContinueWith", timer.Elapsed.ToString());*/


/*timer.Reset();
timer.Start();
await WaysToUseAsync.DelayedTasks();
timer.Stop();
Console.WriteLine("{0} DelayedTasks", timer.Elapsed.ToString());*/


timer.Reset();
timer.Start();
WaysToUseAsync.ParallelHeavyComputation();
timer.Stop();
Console.WriteLine("{0} ParallelHeavyComputation", timer.Elapsed.ToString());
