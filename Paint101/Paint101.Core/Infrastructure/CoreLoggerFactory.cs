using System;

namespace Paint101.Core
{
    public class CoreLoggerFactory
    {
        private static Func<string, ICoreLogger> _factoryMethod;


        static CoreLoggerFactory()
        {
            _factoryMethod = name => new DummyLogger();
        }


        public static void SetFactoryMethod(Func<string, ICoreLogger> factoryMethod)
        {
            _factoryMethod = factoryMethod;
        }

        public static ICoreLogger GetLogger(string name)
        {
            return _factoryMethod(name);
        }
    }
}
