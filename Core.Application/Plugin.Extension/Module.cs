using Core.Contracts;
using Plugin.Contract;
using System.Threading.Tasks;

namespace Plugin.Extension
{
    public class Module : ModuleBase
    {
        public sealed override Task Activate(IContext context)
        {
            var service = context.Get<IService>();
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(500);
                    service.SayHello();
                }
            });
            return Task.CompletedTask;
        }
    }
}
