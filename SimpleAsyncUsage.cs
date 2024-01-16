using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTest {
    public static class SimpleAsyncUsage
    {
        public static async Task SimpleAsyncCall()
        {
            try
            {
                var client = new HttpClient();
                string[] results = await Task.WhenAll(
                    client.GetStringAsync("https://official-joke-api.appspot.com/random_joke"),
                    client.GetStringAsync("https://official-joke-api.appspot.com/random_joke"),
                    client.GetStringAsync("https://official-joke-api.appspot.com/random_joke"),
                    client.GetStringAsync("https://official-joke-api.appspot.com/random_joke")
                );

                results.ToList().ForEach(jk =>
                {
                    var joke = JsonConvert.DeserializeObject<Joke>(jk);
                    Console.WriteLine(joke);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /**
         * get input from jsonPlaceHolder with id
         */
        public static async Task<Input> CallJsonPlaceHolder(int id) {
            try {
                var client = new HttpClient();
                Task<string> task = await Task.Factory.StartNew(() => {
                    return client.GetStringAsync(string.Format("https://jsonplaceholder.typicode.com/todos/{0}", id));
                });

                return JsonConvert.DeserializeObject<Input>(task.Result);
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /**
         * get joke as string from official joke api
         */
        public static async Task<string> GetAJoke() {
            try {
                var client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("https://official-joke-api.appspot.com/random_joke");

                return await response.Content.ReadAsStringAsync();
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            return "";
        }

        public static async Task<string> FetchDataAsync() {
            using (HttpClient httpClient = new HttpClient()) {
                HttpResponseMessage response = await httpClient.GetAsync("https://official-joke-api.appspot.com/random_joke");
                response.EnsureSuccessStatusCode(); // Permet de lever une exception si l'appel n'a pas renvoyé une réponse valable

                return await response.Content.ReadAsStringAsync();
            }
        }

        public static int DoWork(string taskName, int delayMilliseconds) {
            Console.WriteLine("{0} starting...", taskName);
            Task.Delay(delayMilliseconds).Wait();
            Console.WriteLine("{0} completed.", taskName);
            return delayMilliseconds;
        }

        public static int HeavyComputation(string name) {
            Console.WriteLine("Start: " + name);
            var timer = new Stopwatch();
            timer.Start();
            var result = 0;
            for (var i = 0; i < 10_000_000; i++) {
                var a = ((i + 1_500) / (i + 30)) * (i + 10);
                result += (a % 10) - 120;
            }
            timer.Stop();
            Console.WriteLine("End: " + name + ' ' + timer.ElapsedMilliseconds);
            return result;
        }
    }

    public class Input
    {
        public int? UserId { get; set; }
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool? Completed { get; set; }
        

        public override string ToString()
        {
            return $"userId: {UserId}, ID: {Id}, Title: {Title}, Completed: {Completed}";
        }
    }

    public class Joke {
        public string? Type { get; set; }
        public string? Setup { get; set; }
        public string? Punchline { get; set; }
        public int Id { get; set; }

        public override string ToString() {
            return $"Type: {Type}, Setup: {Setup}, Punchline: {Punchline}, Id: {Id}";
        }
    }
}
