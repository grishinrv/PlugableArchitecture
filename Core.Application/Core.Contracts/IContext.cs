using System.Threading.Tasks;

namespace Core.Contracts
{
    /// <summary>
    /// Контекст приложения. Предоставляет доступ через интерфейсы.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Немедленно получить реализацию.
        /// </summary>
        /// <typeparam name="T">Тип, по которому была выполнена привязка</typeparam>
        /// <returns>реализация</returns>
        /// <throws><see cref="ResolveException"/>в случае некорректной компоновки приложения</throws>
        T Get<T>() where T : class;

        /// <summary>
        /// Немедленно получить реализацию.
        /// </summary>
        /// <typeparam name="T">Тип, по которому была выполнена привязка</typeparam>
        /// <param name="priority">для упорядочивания запросов относительно друг друга</param>
        /// <returns>реализация</returns>
        /// <throws><see cref="ResolveException"/>в случае некорректной компоновки приложения</throws>
        Task<T> GetWith<T>(int priority) where T : class;
    }
}
