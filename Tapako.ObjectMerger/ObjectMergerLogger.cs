using System;
using System.Diagnostics;

namespace Tapako.ObjectMerger
{
    public class ObjectMergerLogger : IObjectMergerLogger
    {
        private static IObjectMergerLogger _instance;

        protected ObjectMergerLogger()
        {
            
        }

        public static IObjectMergerLogger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ObjectMergerLogger();
            }
            return _instance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger">if null, the instance will be the default logger</param>
        public static void SetInstance(IObjectMergerLogger logger)
        {
            if (logger == null)
            {
                _instance = new ObjectMergerLogger();
            }
            else
            {
                _instance = logger;
            }
        }

        public void Debug(string message, params object[] paramList)
        {
            var msg = string.Format(message, paramList);
            Trace.WriteLine(msg);
        }

        public void Warning(string message, params object[] paramList)
        {
            var msg = string.Format(message, paramList);
            Trace.WriteLine(msg);
        }

        public void Error(string message, params object[] paramList)
        {
            var msg = string.Format(message, paramList);
            Trace.WriteLine(msg);
        }

        public void Info(string message, params object[] paramList)
        {
            var msg = string.Format(message, paramList);
            Trace.WriteLine(msg);
        }

        public void Debug(Exception exception)
        {
            Debug(exception.ToString());
        }

        public void Warning(Exception exception)
        {
            Warning(exception.ToString());
        }

        public void Error(Exception exception)
        {
            Error(exception.ToString());
        }

        public void Info(Exception exception)
        {
            Info(exception.ToString());
        }
    }
}