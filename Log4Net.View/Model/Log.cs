using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Appender;
using System.ComponentModel;
using System.IO;
using System.Globalization;
using log4net;
using log4net.Core;
using log4net.Config;





namespace Log4NetWPF
{


    /// <summary>
    /// Write out messages using the logging provider.
    /// </summary>
    public static class Log
    {
        #region Members
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Log));
        private static Dictionary<LogLevel, Action<string>> _actions;
        #endregion

        /// <summary>
        /// Static instance of the log manager.
        /// </summary>
        static Log()
        {
            XmlConfigurator.Configure();
            _actions = new Dictionary<LogLevel, Action<string>>();
            _actions.Add(LogLevel.Debug, WriteDebug);
            _actions.Add(LogLevel.Error, WriteError);
            _actions.Add(LogLevel.Fatal, WriteFatal);
            _actions.Add(LogLevel.Info, WriteInfo);
            _actions.Add(LogLevel.Warning, WriteWarning);
        }

        /// <summary>
        /// Get the <see cref="NotifyAppender"/> log.
        /// </summary>
        /// <returns>The instance of the <see cref="NotifyAppender"/> log, if configured. 
        /// Null otherwise.</returns>
        public static NotifyAppender Appender
        {
            get
            {
                foreach (ILog log in LogManager.GetCurrentLoggers())
                {
                    foreach (IAppender appender in log.Logger.Repository.GetAppenders())
                    {
                        if (appender is NotifyAppender)
                        {
                            return appender as NotifyAppender;
                        }
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Write the message to the appropriate log based on the relevant log level.
        /// </summary>
        /// <param name="level">The log level to be used.</param>
        /// <param name="message">The message to be written.</param>
        /// <exception cref="ArgumentNullException">Thrown if the message is empty.</exception>
        public static void Write(LogLevel level, string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (level > LogLevel.Warning || level < LogLevel.Debug)
                    throw new ArgumentOutOfRangeException("level");

                // Now call the appropriate log level message.
                _actions[level](message);
            }
        }

        #region Action methods
        private static void WriteDebug(string message)
        {
            if (_logger.IsDebugEnabled)
                _logger.Debug(message);
        }

        private static void WriteError(string message)
        {
            if (_logger.IsErrorEnabled)
                _logger.Error(message);
        }

        private static void WriteFatal(string message)
        {
            if (_logger.IsFatalEnabled)
                _logger.Fatal(message);
        }

        private static void WriteInfo(string message)
        {
            if (_logger.IsInfoEnabled)
                _logger.Info(message);
        }

        private static void WriteWarning(string message)
        {
            if (_logger.IsWarnEnabled)
                _logger.Warn(message);
        }
        #endregion
    }
}