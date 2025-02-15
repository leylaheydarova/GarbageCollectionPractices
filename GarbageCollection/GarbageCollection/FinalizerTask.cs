namespace GarbageCollection
{
    public class FinalizerTask : IDisposable
    {
        private bool _disposed = false;
        private readonly FileStream _fileStream;
        private readonly StreamWriter _writer;
        private readonly HttpClient _httpClient;
        private IntPtr _unmanagedResource;
        public FinalizerTask(string filePath)
        {
            _fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            _writer = new StreamWriter(_fileStream);
            _httpClient = new HttpClient();
            _unmanagedResource = new IntPtr(123);
        }

        ~FinalizerTask()
        {
            Console.WriteLine("Finalizer is called!");
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
               if (disposing)
               {
                    // Burada managed resursları sərbəst burax
                    _writer?.Dispose();
                    _fileStream.Dispose();
                    _httpClient?.Dispose();
                    Console.WriteLine("Disposing managed resouces.");
               }
                // Burada unmanaged resursları sərbəst burax
                _unmanagedResource = IntPtr.Zero;
                Console.WriteLine("Disposing unmanages resources.");
                _disposed = true;
            }
        }
    }
}
