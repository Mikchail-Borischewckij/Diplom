using Microsoft.Practices.Unity;

namespace HomeFinance.Core.IoC
{
    /// <summary>
    /// This class provide possibility for lazy injection
    /// </summary>
    public class LazyInject<T> where T : class
    {
        /// <summary>
        /// Holds IoC container instance
        /// </summary>
        private readonly IUnityContainer _container;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="container">IoC container</param>
        public LazyInject(IUnityContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Gets value of type T that registered within IoC Container
        /// </summary>
        public T Value
        {
            get { return _container.Resolve<T>(); }
        }

    }
}
