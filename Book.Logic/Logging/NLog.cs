using System;
using NLog;
namespace Book.Logic.Logging
{
    public class NLog : ILogger
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Write debug info into log file.
        /// </summary>
        /// <param name="time">Time of writing.</param>
        /// <param name="recordInfo">Information about record in log file.</param>
        /// <param name="record">Record in log file.</param>
        public void DebugWriteToLog(DateTime time, string recordInfo, string record)
        {
            logger.Info(time);
            logger.Debug(recordInfo);
            logger.Debug(record);
        }

        /// <summary>
        /// Write information about error into log file.
        /// </summary>
        /// <param name="time">Time of writing.</param>
        /// <param name="recordInfo">Information about record in log file.</param>
        /// <param name="record">Record in log file.</param>
        public void InfoWriteToLog(DateTime time, string recordInfo, string record)
        {
            logger.Info(time);
            logger.Info(recordInfo);
            logger.Info(record);
        }

        /// <summary>
        /// Write warn information into log file.
        /// </summary>
        /// <param name="time">Time of writing.</param>
        /// <param name="recordInfo">Information about record in log file.</param>
        /// <param name="record">Record in log file.</param>
        public void WarnWriteToLog(DateTime time, string recordInfo, string record)
        {
            logger.Info(time);
            logger.Warn(recordInfo);
            logger.Warn(record);
        }

        /// <summary>
        /// Write error information into log file.
        /// </summary>
        /// <param name="time">Time of writing.</param>
        /// <param name="recordInfo">Information about record in log file.</param>
        /// <param name="record">Record in log file.</param>
        public void ErrorWriteToLog(DateTime time, string recordInfo, string record)
        {
            logger.Info(time);
            logger.Error(recordInfo);
            logger.Error(record);
        }

        /// <summary>
        /// Write fatal error information into log file.
        /// </summary>
        /// <param name="time">Time of writing.</param>
        /// <param name="recordInfo">Information about record in log file.</param>
        /// <param name="record">Record in log file.</param>
        public void FatalWriteToLog(DateTime time, string recordInfo, string record)
        {
            logger.Info(time);
            logger.Fatal(recordInfo);
            logger.Fatal(record);
        }
    }
}
