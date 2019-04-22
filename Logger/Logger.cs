using log4net;
using log4net.Config;
using System;


namespace Logger
{
    public class Logger : BL_Contracts.ILogger
    {
        private ILog logger;

        static Logger()
        {
            XmlConfigurator.Configure();
        }

        public Logger()
        {
            this.logger = log4net.LogManager.GetLogger("DefaultLogger");
        }

        public void Error(string description, string source)
        {
            this.logger.Error(description + " " + source);
        }

        public void Info(string description, string source)
        {
            this.logger.Info(description + " " + source);
        }

        public void Warning(string description, string source)
        {
            this.logger.Warn(description + " " + source);
        }

        public void Info(string layer,  Exception e)
        {
            this.logger.Info("Layer :" + layer + ". Description: " + e.Message + ". Name of the method that caused exception: " + e.TargetSite + ". Name of the class that caused exception: " + e.TargetSite.DeclaringType);
        }
        public void Error(string layer,  Exception e)
        {
            this.logger.Error("Layer :" + layer + ". Description: " + e.Message + ". Name of the method that caused exception: " + e.TargetSite + ". Name of the class that caused exception: " + e.TargetSite.DeclaringType);
        }
        public void Warning(string layer, Exception e)
        {
            this.logger.Warn("Layer :" + layer + ". Description: " + e.Message + ". Name of the method that caused exception: " + e.TargetSite + ". Name of the class that caused exception: " + e.TargetSite.DeclaringType);
        }
    }
}
