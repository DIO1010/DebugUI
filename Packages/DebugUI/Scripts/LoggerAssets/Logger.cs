using UnityEngine;
using System.IO;
using System;

namespace LoggerAssets
{
  public class Logger
  {
    static readonly string _filepath = "log.csv";

    static Logger _instance = new Logger();
    public static Logger System => _instance;

    public bool isLog = false;

    public Action<DateTime, string, string, LogType> OnCallback = default;

    Logger()
    {
#if DEBUG
      Application.logMessageReceived += LogCallbackHandler;
      File.WriteAllText(_filepath, Format("HH:mm:ss", "condition", "stack trace", "log type"));
#endif
    }

    void LogCallbackHandler(string condition, string stackTrace, LogType type)
    {
      if (isLog)
      {
        DateTime now = DateTime.Now;
        File.AppendAllText(_filepath, Format(now.ToLongTimeString(), condition, stackTrace, type.ToString()));
        OnCallback?.Invoke(now, condition, stackTrace, type);
      }
    }

    string Format(string now, string condition, string stackTrace, string type)
    {
      return $"\"{now}\",\"{type}\",\"{condition}\",\"{stackTrace}\"\r\n";
    }

    public void StartLog() => isLog = true;

    public void EndLog() => isLog = false;
  }
}
