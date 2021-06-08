using System;

namespace Core.Contracts
{
    /// <summary>
    /// Не удалось выполнить запрос реализации.
    /// </summary>
    public class ResolveException : InvalidOperationException
    {
        private readonly string _message;
        public sealed override string Message => _message;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="message">Причина исключения</param>
        public ResolveException(string message) => _message = message;
    }
}
