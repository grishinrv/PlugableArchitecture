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
    }
}
