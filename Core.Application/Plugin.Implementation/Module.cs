using Core.Contracts;
using Plugin.Contract;

namespace Plugin.Implementation
{
    public class Module : ModuleBase
    {
        public sealed override void Init(IContextBuilder builder) => builder.Bind<IService, Service>(true);
    }
}
