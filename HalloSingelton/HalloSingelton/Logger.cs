namespace HalloSingelton
{
    internal class Logger
    {
        private static Logger _instance;
        private static object _lock = new();

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }

                return _instance;
            }
        }

        private Logger()
        {
            Info("Neue Logger instanz");
        }

        public void Info(string msg)
        {
            Console.WriteLine($"[INFO] {DateTime.Now:G} {msg}");
        }
    }
}
