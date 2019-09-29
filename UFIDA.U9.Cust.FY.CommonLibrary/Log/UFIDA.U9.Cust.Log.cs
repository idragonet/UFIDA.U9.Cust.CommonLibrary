using System;
using UFSoft.UBF.Util.Log;

namespace UFIDA.U9.Cust.CommonLibrary.Log
{
    /// <summary>U9日志操作</summary>
    public static class logger
    {
        /// <summary>写入ERROR日志. 级别顺序(由低到高): DEBUG -> INFO -> WARN -> ERROR -> FATAL </summary>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        public static void WriteLogError(string message, Type type = null)
        {
            ILogger logger = LoggerManager.GetLogger("UFIDA.U9.Cust.CommonLibrary.Log");
            if (type != null)
            {
                logger = LoggerManager.GetLogger(type);
            }

            LoggerManager.GetLogger("UFIDA.U9.Cust.CommonLibrary.Log");

            logger.Error(message, new object[0]);
            /*logger.Debug(message, new object[0]);
            logger.Fatal(message, new object[0]);
            logger.Info(message, new object[0]);
            logger.Warn(message, new object[0]);*/
        }

        /// <summary>写入WARN日志.  级别顺序(由低到高): DEBUG -> INFO -> WARN -> ERROR -> FATAL </summary>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        public static void WriteLogDebug(string message, Type type = null)
        {
            ILogger logger = LoggerManager.GetLogger("UFIDA.U9.Cust.CommonLibrary.Log");
            if (type != null)
            {
                logger = LoggerManager.GetLogger(type);
            }
            LoggerManager.GetLogger("UFIDA.U9.Cust.CommonLibrary.Log");

            //            logger.Fatal(message, new object[0]);
            //       logger.Error(message, new object[0]);
            logger.Warn(message, new object[0]);
            //            logger.Info(message, new object[0]);
        }
    }
}