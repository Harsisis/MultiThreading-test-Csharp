using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
         * get input from jsonPlaceHolder id : 1
         */
        public static async Task<Input> CallJsonPlaceHolder1() {
            try {
                var client = new HttpClient();
                Task<string> task = await Task.Factory.StartNew(() => {
                    return client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/1");
                });

                return JsonConvert.DeserializeObject<Input>(task.Result);
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /**
         * get input from jsonPlaceHolder id : 2
         */
        public static async Task<Input> CallJsonPlaceHolder2() {
            try {
                var client = new HttpClient();
                Task<string> task = await Task.Factory.StartNew(() => {
                    return client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/2");
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
