using Lynn.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Lynn.TestClient
{
    public class Program
    {
        private static readonly HttpClient client = new HttpClient();

        public static int? UserID { get; set; }

        public static Uri Uri { get; set; }

        static void Main(string[] args)
        {
            //UserID = 3;
            while (true)
            {
                UserID = Convert.ToInt32(Console.ReadLine());

                var repositories = ProcessRepositories().Result;

                foreach (var repo in repositories)
                {
                    Console.WriteLine(repo.ID);
                    Console.WriteLine(repo.CourseName);
                    Console.WriteLine(repo.LearningLanguage);
                    Console.WriteLine(repo.KnownLanguage);
                    Console.WriteLine();
                }

                //RunAsync();
            }
            //Console.ReadKey();
        }

        private static async Task<ObservableCollection<Course>> ProcessRepositories()
        {
            var serializer = new DataContractJsonSerializer(typeof(ObservableCollection<Course>));

            //client.BaseAddress = new Uri("http://localhost:56749/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrollment"));

            var streamTask = client.GetStreamAsync($"http://localhost:56749/api/enrollment/{UserID}");
            var repositories = serializer.ReadObject(await streamTask) as ObservableCollection<Course>;
            return repositories;
        }

        static async Task<Uri> CreateEnrollmentAsync()
        {
            client.BaseAddress = new Uri("http://localhost:56749/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("api/enrollment"));

            Enrollment enrollment = new Enrollment { CourseId = 1, UserId = 5, Level = 1, Points = 0 };
            HttpResponseMessage response = await client.PostAsJsonAsync("api/enrollment", enrollment);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task RunAsync()
        {
            Uri = await CreateEnrollmentAsync();
            Console.WriteLine(Uri.PathAndQuery);
        }
    }
}
