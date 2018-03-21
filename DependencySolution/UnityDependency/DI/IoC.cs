using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;

namespace UnityDependency.DI
{
    public static class IoC
    {
        private static readonly IUnityContainer _container;

        static IoC()
        {
            _container = new UnityContainer();

            try
            {
                _container.LoadConfiguration();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IUnityContainer DependencyResolver
        {
            get { return _container; }
        }

        /// <summary>
        /// Resolve an instance of T
        /// </summary>
        public static T Resolve<T>()
        {
            try
            {
                return _container.Resolve<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Resolve an instance of T
        /// </summary>
        public static T Resolve<T>(string key)
        {
            try
            {
                return _container.Resolve<T>(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
