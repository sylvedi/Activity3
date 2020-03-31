using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Activity3.Services.Utility
{
    public class MyLogger1 : ILogger
    {

        private static MyLogger1 instance;
        private static Logger logger;

        // Singleton Design Pattern private constructor
        private MyLogger1()
        {

        }

        public static MyLogger1 GetInstance()
        {
            if (instance == null)
                instance = new MyLogger1();
            return instance;
        }


        private Logger Getlogger(string theLogger)
        {
            if (MyLogger1.logger == null)
                MyLogger1.logger = LogManager.GetLogger(theLogger);
            return MyLogger1.logger;
        }

        internal void Info(string v, object p)
        {
            throw new NotImplementedException();
        }

        public void Debug(string message, string arg = null)
        {
            if (arg == null)
                Getlogger("myAppLoggerRules").Debug(message);
            else
                Getlogger("myAppLoggerRules").Debug(message, arg);
        }

       
        public void Error(string message, string arg = null)
        {
            if (arg == null)
                Getlogger("myAppLoggerRules").Error(message);
            else
                Getlogger("myAppLoggerRules").Error(message, arg);
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
                Getlogger("myAppLoggerRules").Info(message);
            else
                Getlogger("myAppLoggerRules").Info(message, arg);
        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
                Getlogger("myAppLoggerRules").Warn(message);
            else
                Getlogger("myAppLoggerRules").Warn(message, arg);
        }

       
    }
}