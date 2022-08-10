namespace ConsoleApp3
{
    internal class Program
    {
        public class Stopwatch
        {
            private readonly DateTime StartTime;
            private DateTime EndTime { get; set; }
            private bool IsRunning = false;
            public TimeSpan Duration { get; set; }

            public Stopwatch(DateTime startTime)
            {
                this.StartTime = startTime;
            }

            public void Start()
            {
                if(IsRunning == false)
                {
                    IsRunning = true;
                    Console.WriteLine("Stopwatch started");
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
            Stopwatch watch = new Stopwatch(DateTime.UtcNow);

            try
            {
                watch.Start();
                Thread.Sleep(5000);
                watch.Stop();
                Console.WriteLine($"Stopwatch was running for total duration of {watch.Duration}");
            }
            catch (InvalidOperationException)
            {
                throw;
            }

            try
            {
                watch.Start();
                Thread.Sleep(3000);
                watch.Stop();
                Console.WriteLine($"Stopwatch was running for total duration of {watch.Duration}");
            }
            catch (InvalidOperationException)
            {
                throw;
            }

            try
            {
                watch.Start();
                watch.Start();
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }
    }
}