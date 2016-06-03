using System;
using System.Diagnostics;
using System.IO;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;

namespace HomeFinance.Core
{
    public static class TLog
    {
        private static readonly Subject<LogItem> _subject = new Subject<LogItem>();

        static TLog()
        {
            _subject.SubscribeOn(Scheduler.ThreadPool)
                .ObserveOn(new EventLoopScheduler())
                .Subscribe(logItem =>
                {
                    try
                    {
                        File.AppendAllText(@"C:\LogFiles\CorpLib\log.txt", logItem.RenderedMessage);
                    }
                    catch (Exception ex)
                    {
                    }
                });
        }

        public static void Write(LogItem logItem)
        {
            _subject.OnNext(logItem);
        }

        public static void Write(params object[] parts)
        {
            Write(new LogItem(parts));
        }
    }

    public class LogItem : IDisposable
    {
        private readonly Stopwatch _sw;

        public DateTime TimeStampStart { get; private set; }
        public DateTime TimeStampEnd { get; private set; }
        public string Message { get; private set; }
        public string ThreadId { get; private set; }
        public string ProcessId { get; private set; }
        public TimeSpan Elapsed { get; private set; }

        public string RenderedMessage
        {
            get
            {
                string timestamp = TimeStampStart.ToUniversalTime().ToString("O");
                string timeStamp1 = GetTimeStamp(TimeStampStart);
                string timeStamp2 = GetTimeStamp(TimeStampEnd);
                string delay = Elapsed.TotalMilliseconds.ToString("F0");
                //string message = string.Format("{6}\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\n", ProcessId, ThreadId, timeStamp1, timeStamp2, delay, Message, timestamp);
                string message = string.Format("{0}\t{1}\t{2}\t{3}\n", timestamp, ProcessId, ThreadId, Message);
                return message;
            }
        }

        public LogItem(string message)
        {
            Message = message;
            ThreadId = Thread.CurrentThread.ManagedThreadId.ToString("X4");
            ProcessId = Process.GetCurrentProcess().Id.ToString();
            TimeStampStart = DateTime.Now;
            _sw = Stopwatch.StartNew();
        }

        public LogItem(params object[] parts)
            : this(CreateMessage(parts))
        {
        }

        private static string CreateMessage(params object[] parts)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < parts.Length; i++)
            {
                sb.Append(parts[i] ?? "null");
                sb.Append(" ");
            }
            return sb.ToString();
        }

        public void Dispose()
        {
            _sw.Stop();
            TimeStampEnd = DateTime.Now;
            Elapsed = _sw.Elapsed;
            TLog.Write(this);
        }

        private string GetTimeStamp(DateTime dateTime)
        {
            return (dateTime - DateTime.Today).TotalMilliseconds.ToString("##########");
        }
    }

}
