namespace ConsoleApp3
{
    internal class Program
    {
        public class Stopwatch
        {
            private DateTime StartTime { get; set; }
            private DateTime EndTime { get; set; }
            public TimeSpan Duration { get; set; }
            private bool IsRunning = false;

            public void Start()
            {
                if(IsRunning == false && Duration.TotalMilliseconds == 0)
                {
                    IsRunning = true;
                    Console.WriteLine("Stopwatch started");
                    StartTime = DateTime.UtcNow;
                }
                else if (IsRunning == false && Duration.TotalMilliseconds > 0)
                {
                    Console.WriteLine("Stopwatch resumed");
                    IsRunning = true;
                }
                else
                {
                    throw new InvalidOperationException("Cannot start stopwatch as it is already running");
                }
            }

            public void Stop()
            {
                if (IsRunning == false)
                {
                    throw new InvalidOperationException("Cannot stop stopwatch as it is not running");
                }
                else
                {
                    EndTime = DateTime.UtcNow;

                    Console.WriteLine($"Stopwatch stopped");

                    Duration = EndTime - StartTime;

                    IsRunning = false;
                }
            }
        }
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();

            //1st iteration to make sure subtraction is working correctly
            try
            {
                watch.Start();
                Thread.Sleep(5000);
                watch.Stop();
                Console.WriteLine($"Stopwatch was running for total duration of {watch.Duration}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

            //2nd iteration to make sure readonly field is retaining the value set in the constructor and StartTime is not overwritten
            try
            {
                watch.Start();
                Thread.Sleep(3000);
                watch.Stop();
                Console.WriteLine($"Stopwatch was running for total duration of {watch.Duration}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }

            //This should fail as stopwatch is already running
            try
            {
                watch.Start();
                watch.Start();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"{e.Message}");
            }

            //This should also fail as stopwatch is not running
            //try
            //{
            //    watch.Stop();
            //}
            //catch (InvalidOperationException e)
            //{
            //    Console.WriteLine($"{e.Message}");
            //}
        }
    }
}