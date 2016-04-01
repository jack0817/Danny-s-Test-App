using DannysTestApp.Model;
using DannysTestApp.Model.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannysTestApp.Services
{
    public class LogService : ServiceBase
    {
        public Type SourceType { get; private set; }

        public LogService(Type sourceType)
        {
            this.SourceType = sourceType;
        }

        public void Error(Exception ex)
        {
            if (ex == null)
                return;

            var msg = string.Format("{0}\n{1}", ex.Message, ex.StackTrace);
            this.Log(LogLevel.Error, msg);
        }

        public void Error(string msg)
        {
            this.Log(LogLevel.Error, msg);
        }

        private void Log(LogLevel level, string message)
        {
            var log = new Log
            {
                LogId = Guid.NewGuid().ToString(),
                Level = level,
                LogDate= DateTime.Now,
                Message = message,
                Source = this.SourceType.FullName,
            };

            this.DataContext.Insert(log);
        }
    }
}
