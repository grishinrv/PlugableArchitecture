using Core.Contracts;

namespace Plugin.Logger
{
    public class Module : ModuleBase
    {
        public sealed override void Init(IContextBuilder builder) => builder.Bind<ILogger, Logger>();
    }
}
