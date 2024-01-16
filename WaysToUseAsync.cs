using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTest {
    public static class WaysToUseAsync
    {
        public static async Task<string> DoTasksV1(string message)
        {
            Console.WriteLine("{0} Entering in method DoTasksV1", DateTime.Now);
            await FakeAsyncTasks.SendEmailAsync();
            var randomNumber = await FakeAsyncTasks.GetRandomNumberAsync();
            var upperString = await FakeAsyncTasks.GetSpecialStringAsync(message);
            Console.WriteLine("{0} Out of method DoTasksV1", DateTime.Now);
            return string.Format("{0}-{1}", randomNumber, upperString);
        }

        public static async Task<string> DoTasksV2(string message)
        {
            Console.WriteLine("{0} Entering in method DoTasksV2", DateTime.Now);
            var emailTask = FakeAsyncTasks.SendEmailAsync();
            var randomNumber = await FakeAsyncTasks.GetRandomNumberAsync();
            var upperString = await FakeAsyncTasks.GetSpecialStringAsync(message);
            await emailTask;
            Console.WriteLine("{0} Out of method DoTasksV2", DateTime.Now);
            return string.Format("{0}-{1}", randomNumber, upperString);
        }

        public static async Task<string> DoTasksV3(string message)
        {
            Console.WriteLine("{0} Entering in method DoTasksV3", DateTime.Now);
            var emailTask = FakeAsyncTasks.SendEmailAsync();
            var numberTask = FakeAsyncTasks.GetRandomNumberAsync();
            var stringTask = FakeAsyncTasks.GetSpecialStringAsync(message);
            
            await emailTask;
            var randomNumber = await numberTask;
            var upperString = await stringTask;
            Console.WriteLine("{0} Out of method DoTasksV3", DateTime.Now);
            return string.Format("{0}-{1}", randomNumber, upperString);
        }

        public static async Task<string> DoTasksV4(string message)
        {
            Console.WriteLine("{0} Entering in method DoTasksV4", DateTime.Now);
            var emailTask = FakeAsyncTasks.SendEmailAsync();
            var numberTask = FakeAsyncTasks.GetRandomNumberAsync();
            var stringTask = FakeAsyncTasks.GetSpecialStringAsync(message);

            await Task.WhenAll(emailTask, numberTask, stringTask);
            Console.WriteLine("{0} Out of method DoTasksV4", DateTime.Now);
            var randomNumber = numberTask.Result.ToString();
            var upperString = stringTask.Result;
            return string.Format("{0}-{1}", randomNumber, upperString);
        }

        public static async Task<string> DoTasksV5(string message)
        {
            Console.WriteLine("{0} Entering in method DoTasksV5", DateTime.Now);

            var todo1 = SimpleAsyncUsage.CallJsonPlaceHolder(1);
            var todo2 = SimpleAsyncUsage.CallJsonPlaceHolder(2);
            var joke = SimpleAsyncUsage.GetAJoke();

            List<Task> allTasks = new List<Task> { todo1, todo2 };
            int randomNumber = 0;
            string upperString = string.Empty;

            while (allTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(allTasks);
                if (finishedTask == todo1)
                {
                    Console.WriteLine("todo 1 :\n {0}", todo1.Result);
                    await Task.Factory.StartNew(() => SimpleAsyncUsage.CallJsonPlaceHolder(3)); // not called
                }
                else if (finishedTask == todo2)
                {
                    Console.WriteLine("todo 2 :\n {0}", todo2.Result);
                } 
                allTasks.Remove(finishedTask);
            }
            Console.WriteLine("{0} Out of method DoTasksV5", DateTime.Now);

            return string.Format("{0}-{1}", randomNumber, upperString);
        }

        public static async Task<string> DoTasksContinueWith() {

            var t1 = Task.Run(() => 5);
            var t2 = t1.ContinueWith(t => t.Result * 2);
            var t3 = t2.ContinueWith(t => t.Result + 10);

            t3.ContinueWith(t => Console.WriteLine(t.Result));



            Console.Out.WriteLine("Start continueTasks");

            Task<string> originalTask = SimpleAsyncUsage.FetchDataAsync();

            Task continuationTask = originalTask.ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion) {
                    Console.WriteLine(task.Result);
                    Console.WriteLine("The task has run successfully");
                } else if (task.Status == TaskStatus.Faulted) {
                    Console.WriteLine("An error occured during call");
                }
            });

            await continuationTask;
            return "";
        }

    }
}
