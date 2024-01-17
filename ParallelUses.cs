using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTest {
    public static class ParallelUses {
        public static async void DisplayListNumbersUsingParallelForeach(List<int> list, int sleepTimer) {
            Console.WriteLine("{0} Entering in method DisplayListNumbersUsingParallelForeach", DateTime.Now);
            Parallel.ForEach(list, number => {
                Console.WriteLine("Current number is {0}", number);
                Thread.Sleep(sleepTimer);
            });
            Console.WriteLine("{0} Out of method DisplayListNumbersUsingParallelForeach", DateTime.Now);
        }

        public static async void DisplayListNumbersUsingParallelFor(List<int> list, int sleepTimer) {
            Console.WriteLine("{0} Entering in method DisplayListNumbersUsingParallelFor", DateTime.Now);
            Parallel.For(0, list.Count,
                   number => {
                       Console.WriteLine("Current number is {0}", list[number]);
                       Thread.Sleep(sleepTimer);
                   });
            Console.WriteLine("{0} Out of method DisplayListNumbersUsingParallelFor", DateTime.Now);
        }

        public static async void DisplayListNumbersUsingParallelInvoke(List<int> list, List<int> list2) {
            Console.WriteLine("{0} Entering in method DisplayListNumbersUsingParallelInvoke", DateTime.Now);
            Parallel.Invoke(() => {
                DisplayListNumbersUsingParallelForeach(list, 1000);
            },
            () => {
                DisplayListNumbersUsingParallelForeach(list2, 1500);
            });
            Console.WriteLine("{0} Out of method DisplayListNumbersUsingParallelInvoke", DateTime.Now);
        }

        public static int SumListNumbersUsingParallelInvokeAndAggregate(List<int> list) {
            Console.WriteLine("{0} Entering in method SumListNumbersUsingParallelInvokeAndAggregate", DateTime.Now);
            var sum = 0;
            Parallel.Invoke(() => {
                sum = list.Aggregate((a, b) => a + b);
            });
            Console.WriteLine("{0} Out of method SumListNumbersUsingParallelInvokeAndAggregate", DateTime.Now);
            return sum;
        }
    }
}
