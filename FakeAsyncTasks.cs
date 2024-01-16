using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTest {
    public static class FakeAsyncTasks
    {
        public static async Task SendEmailAsync()
        {
            Console.WriteLine("{0} SendEmail", DateTime.Now);
            await Task.Delay(2000);
        }

        public static async Task<int> GetRandomNumberAsync()
        {
            Console.WriteLine("{0} GetRandomNumber", DateTime.Now);
            await Task.Delay(2000);
            return new Random().Next(1,10);
        }

        public static async Task<string> GetSpecialStringAsync(string message)
        {
            Console.WriteLine("{0} GetSpecialString", DateTime.Now);
            await Task.Delay(2000);
            return string.IsNullOrEmpty(message) ? "<Nothing>" : message.ToUpper();
        }
    }
}
