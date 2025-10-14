using System.Diagnostics;

namespace AsyncDemoApp
{
    public class Program

    {
        static async Task Main()
        {
            Console.WriteLine("=== Async Demo Started ===");
            var stopwatch = Stopwatch.StartNew();

            // 3 ta ishni parallel bajarish
            var userTask = LoadUsersAsync();
            var carTask = LoadCarsAsync();
            var weatherTask = LoadWeatherAsync();

            await Task.WhenAll(userTask, carTask, weatherTask);

            stopwatch.Stop();
            Console.WriteLine($"\nAll tasks completed in {stopwatch.ElapsedMilliseconds} ms");
        }

        static async Task LoadUsersAsync()
        {
            Console.WriteLine("Loading users...");
            await Task.Delay(2000); // Tasavvur qil, bu API dan yuklayapti
            Console.WriteLine("✅ Users loaded.");
        }

        static async Task LoadCarsAsync()
        {
            Console.WriteLine("Loading cars...");
            await Task.Delay(3000);
            Console.WriteLine("✅ Cars loaded.");
        }

        static async Task LoadWeatherAsync()
        {
            Console.WriteLine("Loading weather...");
            await Task.Delay(1500);
            Console.WriteLine("✅ Weather loaded.");
        }
    }
}
