using Core.Contracts;
using Plugin.Contract;
using System.Threading;

namespace Plugin.Implementation
{
    public class Service : IService
    {
        private readonly ILogger _logger;
        private int _helloCounter;
        public Service(ILogger logger)
        {
            _logger = logger;
        }

        public void SayHello()
        {
            _logger.Debug($"Hello № {Interlocked.Increment(ref _helloCounter)} from {nameof(Service)}");
        }
    }
}
