using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace MomentX
{
    public interface IMethodTimer
    { }

    public class LongWinded : IMethodTimer
    {

        public LongWinded()
        {
        }

        public string Gettime()
        {
            string output = "";
            MethodTimerConfig.Current.DefaultLogAction = x => output += x.ToString() + "\n";
            this.StartTimer("Whole Method");
            BigComputation();
            this.LogElapsed("Whole Method");
            Thread.Sleep(2000);
            this.LogElapsed("Whole Method");

            this.StartTimer();
            Thread.Sleep(1000);
            this.LogElapsed();
            this.LogElapsed("Whole Method");
            return output;
        }
        public void BigComputation()
        {
            Thread.Sleep(3000);
        }
    }

    public class MethodTimerConfig
    {
        private static MethodTimerConfig instance = new MethodTimerConfig();
        public static MethodTimerConfig Current { get { return instance; }}

        static MethodTimerConfig() {}

        private MethodTimerConfig()
        {
            DefaultLogAction = Console.WriteLine;
        }

        public Action<long> DefaultLogAction { get; set; }
    }
    public static class MethodTimerExtensions
    {
        private static readonly Dictionary<string, Stopwatch> Timers = new Dictionary<string, Stopwatch>(); 
        public static void StartTimer(this IMethodTimer This, string identifier = null)
        {
            identifier = identifier ?? String.Empty;
            if (Timers.ContainsKey(identifier ?? String.Empty))
            {
                Timers[identifier].Reset();
                Timers[identifier].Start();
            }
            else
            {
                var watch = new Stopwatch();
                Timers.Add(identifier, watch);
                watch.Start();
            }
        }

        public static void LogElapsed(this IMethodTimer This, string identifier = null, Action<long> logAction = null)
        {
            identifier = identifier ?? String.Empty;

            Timers[identifier].Stop();
            logAction = logAction ?? MethodTimerConfig.Current.DefaultLogAction;

            logAction(Timers[identifier].ElapsedMilliseconds);
            Timers[identifier].Start();
        }

        public static void ResetTimer(this IMethodTimer This, string identifier = null)
        {
            identifier = identifier ?? String.Empty;
            Timers[identifier].Reset();
        }
        public static long TimeMethod(this IMethodTimer This, Action method)
        {
            long time = 0;
            using (new MethodTimer((long x) => time = x))
            {
                method();
            }
            return time;
        }
    }
    public class MethodTimer : IDisposable
    {
        private static readonly Stopwatch Stopwatch = new Stopwatch();

        private readonly Action<TimeSpan> _doneAction;
        private readonly Action<long> _doneWithMilliseconds;
        private readonly Action<string> _doneWithString;
        
        public MethodTimer(Action<TimeSpan> doneAction)
        {
            _doneAction = doneAction;
            Stopwatch.Start();
        }

        public MethodTimer(Action<long> doneWithMilliseconds)
        {
            _doneWithMilliseconds = doneWithMilliseconds;
            Stopwatch.Start();
        }

        public MethodTimer(Action<string> timeTakenAction)
        {
            _doneWithString = timeTakenAction;
            Stopwatch.Start();
        }
        public void Dispose()
        {
            Stopwatch.Stop();
            if (_doneAction != null)
                _doneAction(Stopwatch.Elapsed);
            if (_doneWithMilliseconds != null)
                _doneWithMilliseconds(Stopwatch.ElapsedMilliseconds);

            //TODO upgrade to a more exact FromNow version
            if (_doneWithString != null)
                _doneWithString(Stopwatch.Elapsed.FromNow(false));
            Stopwatch.Reset();
        }
    }
}