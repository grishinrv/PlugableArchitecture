namespace Core.Contracts
{
    /// <summary>
    /// Построитель контекста.
    /// </summary>
    public interface IContextBuilder
    {
        /// <summary>
        /// Регистрация в контейнере (fluent).
        /// </summary>
        /// <typeparam name="TInterface">тип интерфейса</typeparam>
        /// <typeparam name="TImplementation">тип реализации</typeparam>
        /// <param name="isSingleton">тип лайв тайма</param>
        IContextBuilder Bind<TInterface, TImplementation>(bool isSingleton = false) 
            where TInterface : class
            where TImplementation : TInterface;
    }
}
