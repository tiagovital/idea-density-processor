using System;

namespace Infrastructure.CrossCutting
{
    public static class Guard
    {
        public static void Against<TException>(bool assertion, string message) where TException : Exception
        {
            Against<TException>(assertion, message, innerException: null);
        }

        /// <summary>
        /// Will throw exception of type <typeparamref name="TException"/> with the specified message
        /// if the assertion is true
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="assertion">If set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <exception cref="System.ApplicationException">
        /// Thrown when the type <typeparamref name="TException"/> is incorrectly defined.
        /// </exception>
        public static void Against<TException>(bool assertion, string message, Exception innerException)
            where TException : Exception
        {
            if (!assertion)
            {
                return;
            }

            var ctor = typeof(TException).GetConstructor(new Type[] { typeof(string), typeof(Exception) });

            if (ctor != null)
            {
                throw (TException)ctor.Invoke(new object[] { message, innerException });
            }
            else
            {
                var safeInnerException = new Exception(message, innerException);
                throw new ApplicationException(
                    string.Format("The exception type {0} doesn't support the required constructors", typeof(TException)),
                    safeInnerException);
            }
        }
    }
}