using System.Diagnostics;
using System.Threading.Tasks;
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


/*timer.Reset();
timer.Start();
WaysToUseAsync.ParallelHeavyComputation();
timer.Stop();
Console.WriteLine("{0} ParallelHeavyComputation", timer.Elapsed.ToString());*/


List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
/*STEP 1 - 2*/
/*
timer.Reset();
timer.Start();
ParallelUses.DisplayListNumbersUsingParallelForeach(list, 1000);
timer.Stop();
Console.WriteLine("{0} DisplayListNumbersUsingParallelForeach", timer.Elapsed.ToString());*:

/*STEP 3*/
/*timer.Reset();
timer.Start();
ParallelUses.DisplayListNumbersUsingParallelFor(list, 1000);
timer.Stop();
Console.WriteLine("{0} DisplayListNumbersUsingParallelFor", timer.Elapsed.ToString());*/

/*STEP 4*/
List<int> list2 = new List<int>() { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};
/*timer.Reset();
timer.Start();
ParallelUses.DisplayListNumbersUsingParallelInvoke(list, list2);
timer.Stop();
Console.WriteLine("{0} DisplayListNumbersUsingParallelInvoke", timer.Elapsed.ToString());*/


/*STEP 5*/
List<int> numbers = new List<int>();
for (int i = 1; i <= 100; i++) {
    numbers.Add(i);
}
timer.Reset();
timer.Start();
int sum = ParallelUses.SumListNumbersUsingParallelInvokeAndAggregate(numbers);
timer.Stop();
Console.WriteLine("La somme des valeurs de 1 à 100 est : {0} en {1}", sum, timer.Elapsed.ToString());

timer.Reset();
timer.Start();
sum = numbers.Sum();
timer.Stop();
Console.WriteLine("somme en utilisant la fonction sum() : {0} en {1}", sum, timer.Elapsed.ToString());

/*STEP 6*/

ParallelUses.ReadFilesAmount();
