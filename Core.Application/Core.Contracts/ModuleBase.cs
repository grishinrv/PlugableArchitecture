using System.Threading.Tasks;

namespace Core.Contracts
{
    /// <summary>
    /// Описатель слабо-связанного модуля.
    /// </summary>
    public abstract class ModuleBase
    {
        /// <summary>
        /// Стадия инициализации. Тут можно выполнить связывание интерфейсов и реализаций.
        /// </summary>
        public virtual void Init(IContextBuilder builder)
        { }

        /// <summary>
        /// Стадия активации. Тут выполняются действия, необходимые для старта работы модуля.
        /// </summary>
        public virtual Task Activate(IContext context) => Task.CompletedTask;
    }
}
